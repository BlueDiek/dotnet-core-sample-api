using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Consulting.Application.Services;
using Consulting.Domain.IService;
using Consulting.Domain.Models;
using Consulting.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Consulting.Presentation.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class ConsultingController : Controller
    {
        #region Private Properties

        private IConsultingService _consultingService;
        private ILogger _logger;

        #endregion

        public ConsultingController(IConsultingService consultingService, ILogger<ConsultingController> logger)
        {
            _consultingService = consultingService ?? throw new ArgumentNullException(nameof(ConsultingService));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        #region USER
        [HttpGet("user/id/{id}")]
        [ProducesResponseType(typeof(User), 200)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.GetUserById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet("user/uid/{uid}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<User>> GetUser(Guid uid)
        {
            try
            {
                if (uid ==null || uid.Equals(Guid.Empty) ) return BadRequest();
                var result = await _consultingService.GetUserByUid(uid);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpDelete("user/id/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.DeleteUser(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpPost("user/insert")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PostUser([FromBody] User user)
        {
            try
            {
                if (user ==null || user.ID>0 ||user.UID == null || user.UID.Equals(Guid.Empty)) return BadRequest();
                var result = await _consultingService.InsertUser(user);
                if (result <=0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
      
        [HttpPut("user/update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PutUser([FromBody] User user)
        {
            try
            {
                if (user == null || user.ID<=0 || user.UID == null || user.UID.Equals(Guid.Empty)) return BadRequest();
                var result = await _consultingService.UpdateUser(user);
                if (result <=0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion

        #region PERSON
        [HttpGet("person/id/{id}")]
        [ProducesResponseType(typeof(Person), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.GetPersonById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet("user/id/{userId}/persons")]
        [ProducesResponseType(typeof(IEnumerable<Person>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByUser(int  userId)
        {
            try
            {
                if (userId<=0) return BadRequest();
                var result = await _consultingService.GetPersonByUserId(userId);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("person/id/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<bool>> DeletePerson(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.DeletePerson(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("person/insert")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PostPerson([FromBody] Person person)
        {
            try
            {
                if (person == null || person.ID > 0 || person.UserID == null ||string.IsNullOrEmpty(person.Reference)) return BadRequest();
                var result = await _consultingService.InsertPerson(person);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("person/update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PutPerson([FromBody] Person person)
        {
            try
            {
                if (person == null || person.ID <= 0 || person.UserID == null || person.UserID<=0) return BadRequest();
                var result = await _consultingService.UpdatePerson(person);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion

        #region FORM
        [HttpGet("form/id/{id}")]
        [ProducesResponseType(typeof(Form), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Form>> GetForm(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.GetFormById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("forms")]
        [ProducesResponseType(typeof(IEnumerable<Form>), 200)]       
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<IEnumerable<Form>>> GetForms()
        {
            try
            {                
                var result = await _consultingService.GetForms();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("form/id/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<bool>> DeleteForm(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.DeleteForm(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("form/insert")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PostForm([FromBody] Form form)
        {
            try
            {
                if (form == null || form.ID > 0 || string.IsNullOrEmpty( form.Name)) return BadRequest();
                var result = await _consultingService.InsertForm(form);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("form/update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PutForm([FromBody] Form form)
        {
            try
            {
                if (form == null || form.ID <= 0 || string.IsNullOrEmpty(form.Name)) return BadRequest();
                var result = await _consultingService.UpdateForm(form);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
     
        #region FORMQUESTION
        [HttpGet("formQuestion/id/{id}")]
        [ProducesResponseType(typeof(FormQuestion), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<FormQuestion>> GetFormQuestion(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.GetFormQuestionById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet("form/id/{form_id}/formQuestions")]
        [ProducesResponseType(typeof(IEnumerable<FormQuestion>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<IEnumerable<FormQuestion>>> GetFormQuestions(int form_id)
        {
            try
            {
                if (form_id <= 0) return BadRequest();
                var result = await _consultingService.GetFormQuestions_by_Form(form_id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("formQuestion/id/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<bool>> DeleteFormQuestion(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.DeleteFormQuestion(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("formQuestion/insert")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PostFormQuestion([FromBody] FormQuestion formQuestion)
        {
            try
            {
                if (formQuestion == null || formQuestion.ID > 0 || formQuestion.FormID <= 0 || formQuestion.Order<=0) return BadRequest();
                var result = await _consultingService.InsertFormQuestion(formQuestion);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("formQuestion/update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PutFormQuestion([FromBody] FormQuestion formQuestion)
        {
            try
            {
                if (formQuestion == null || formQuestion.ID <= 0 || formQuestion.FormID <=0 ) return BadRequest();
                var result = await _consultingService.UpdateFormQuestion(formQuestion);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
     
        #region QUESTION
        [HttpGet("question/id/{id}")]
        [ProducesResponseType(typeof(Question), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.GetQuestionById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }    

        [HttpDelete("question/id/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<bool>> DeleteQuestion(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.DeleteQuestion(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("question/insert")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PostQuestion([FromBody] Question question)
        {
            try
            {
                if (question == null || question.ID > 0 || question.QuestionTypeID <=0 || string.IsNullOrEmpty(question.Name)) return BadRequest();
                var result = await _consultingService.InsertQuestion(question);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("question/update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PutUser([FromBody] Question question)
        {
            try
            {
                if (question == null || question.ID <= 0 || question.QuestionTypeID <=0 || string.IsNullOrEmpty (question.Name)) return BadRequest();
                var result = await _consultingService.UpdateQuestion(question);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
    
        #region QUESTIONTYPE
        [HttpGet("questiontype/id/{id}")]
        [ProducesResponseType(typeof(QuestionType), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<QuestionType>> GetQuestionType(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.GetQuestionTypeById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet("questiontypes")]
        [ProducesResponseType(typeof(IEnumerable<QuestionType>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<IEnumerable<QuestionType>>> GetQuestionType()
        {
            try
            {               
                var result = await _consultingService.GetQuestionTypes();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("questiontype/id/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<bool>> DeleteQuestionType(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.DeleteQuestionType(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("questiontype/insert")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PostQuestionType([FromBody] QuestionType questionType)
        {
            try
            {
                if (questionType == null || questionType.ID > 0 || string.IsNullOrEmpty(questionType.Name)) return BadRequest();
                var result = await _consultingService.InsertQuestionType(questionType);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("questiontype/update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PutQuestionType([FromBody] QuestionType questionType)
        {
            try
            {
                if (questionType == null || questionType.ID <= 0 || string.IsNullOrEmpty(questionType.Name)) return BadRequest();
                var result = await _consultingService.UpdateQuestionType(questionType);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
    
        #region QUESTIONVALUE
        [HttpGet("questionvalue/id/{id}")]
        [ProducesResponseType(typeof(QuestionValue), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<QuestionValue>> GetQuestionValue(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.GetQuestionValueById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet("question/id/{questionId}/values")]
        [ProducesResponseType(typeof(IEnumerable<QuestionValue>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<IEnumerable<QuestionValue>>> GetQuestionValues_by_Question(int questionId)
        {
            try
            {
                if (questionId <=0) return BadRequest();
                var result = await _consultingService.GetQuestionValues_by_Question(questionId);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("questionvalue/id/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<bool>> DeleteQuestionValue(int id)
        {
            try
            {
                if (id < 1) return BadRequest();
                var result = await _consultingService.DeleteQuestionValue(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("questionvalue/insert")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PostQuestionValue([FromBody] QuestionValue questionValue)
        {
            try
            {
                if (questionValue == null || questionValue.ID > 0 || string.IsNullOrEmpty(questionValue.Name)) return BadRequest();
                var result = await _consultingService.InsertQuestionValue(questionValue);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("questionvalue/update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<int>> PutQuestionValue([FromBody] QuestionValue questionValue)
        {
            try
            {
                if (questionValue == null || questionValue.ID <= 0 || string.IsNullOrEmpty(questionValue.Name)) return BadRequest();
                var result = await _consultingService.UpdateQuestionValue(questionValue);
                if (result <= 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Npgsql.PostgresException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database code: {ex.SqlState}");

            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Error with database. {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion

    }
}
