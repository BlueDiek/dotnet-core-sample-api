using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Consulting.Domain.IRepository;
using Consulting.Domain.Models.Entities;
using Dapper;
using Microsoft.Extensions.Logging;


namespace Consulting.Infrastructure.Repositories
{
    public class ConsultingRepository : IConsultingRepository
    {
        private const string DATABASE_NAME_CONSULTING = "brgzbqcf";     

        private readonly ILogger<ConsultingRepository> _logger;

        protected IDbConnection _connection;

        private readonly IDictionary<string, string> StoreProcedures;




        public ConsultingRepository(IDbConnection dbConnection, ILogger<ConsultingRepository> logger)
        {
            _connection = dbConnection;       
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            StoreProcedures = new Dictionary<string, string>()
            {
                {"InsertUser",                          "FRQ_INSERT_USER"},
                {"InsertFormQuestion",                  "FRQ_INSERT_FORMQUESTION"},
                {"InsertQuestionValue",                 "FRQ_INSERT_QUESTIONVALUE"},
                {"InsertQuestion",                      "FRQ_INSERT_QUESTION"},
                {"InsertQuestionType",                  "FRQ_INSERT_QUESTIONTYPE"},
                {"InsertForm",                          "FRQ_INSERT_FORM"},
                {"InsertPerson",                        "FRQ_INSERT_PERSON"},

                {"UpdateUser",                          "FRQ_UPDATE_USER"},
                {"UpdateFormQuestion",                  "FRQ_UPDATE_FORMQUESTION"},
                {"UpdateQuestionValue",                 "FRQ_UPDATE_QUESTIONVALUE"},
                {"UpdateQuestion",                      "FRQ_UPDATE_QUESTION"},
                {"UpdateQuestionType",                  "FRQ_UPDATE_QUESTIONTYPE"},
                {"UpdateForm",                          "FRQ_UPDATE_FORM"},
                {"UpdatePerson",                        "FRQ_UPDATE_PERSON"},

                {"DeleteUser",                          "FRQ_DELETE_USER"},
                {"DeleteFormQuestion",                  "FRQ_DELETE_FORMQUESTION"},
                {"DeleteQuestionValue",                 "FRQ_DELETE_QUESTIONVALUE"},
                {"DeleteQuestion",                      "FRQ_DELETE_QUESTION"},
                {"DeleteQuestionType",                  "FRQ_DELETE_QUESTIONTYPE"},
                {"DeleteForm",                          "FRQ_DELETE_FORM"},
                {"DeletePerson",                        "FRQ_DELETE_PERSON"},

                {"GetUserById",                         "FRQ_GET_USER"},
                {"GetUserByUid",                        "FRQ_GET_USER"},
                {"GetPersonById",                       "FRQ_GET_PERSON"},
                {"GetPersonByUserId",                   "FRQ_GET_PERSON_BY_USER"},
                {"GetFormById",                         "FRQ_GET_FORM"},
                {"GetForms",                            "FRQ_GET_FORMS"},
                {"GetQuestionTypeById",                 "FRQ_GET_QUESTIONTYPE"},
                {"GetQuestionTypes",                    "FRQ_GET_QUESTIONTYPES"},
                {"GetQuestionById",                     "FRQ_GET_QUESTION"},
                {"GetQuestions",                        "FRQ_GET_QUESTIONS"},
                {"GetQuestionValueById",                "FRQ_GET_QUESTIONVALUE"},
                {"GetQuestionValues_by_Question",       "FRQ_GET_QUESTIONVALUE_BY_QUESTION"},
                {"GetFormQuestionById",                 "FRQ_GET_FORMQUESTION"},
                {"GetFormQuestions_by_Form",            "FRQ_GET_FORMQUESTION_BY_FORM"}
            };
        }


        #region DELETE
        public async Task<bool> DeleteForm(int id)
        {
            string sp = StoreProcedures["DeleteForm"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                bool result = false;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault()) > 0;
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteFormQuestion(int id)
        {
            string sp = StoreProcedures["DeleteFormQuestion"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                bool result = false;
                if (result_query != null && result_query.Any())
                {

                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault()) > 0;
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeletePerson(int id)
        {
            string sp = StoreProcedures["DeletePerson"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                bool result = false;
                if (result_query != null && result_query.Any())
                {

                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault()) > 0;
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            string sp = StoreProcedures["DeleteQuestion"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                bool result = false;
                if (result_query != null && result_query.Any())
                {

                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault()) > 0;
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteQuestionType(int id)
        {
            string sp = StoreProcedures["DeleteQuestionType"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                bool result = false;
                if (result_query != null && result_query.Any())
                {

                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault()) > 0;
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteQuestionValue(int id)
        {
            string sp = StoreProcedures["DeleteQuestionValue"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                bool result = false;
                if (result_query != null && result_query.Any())
                {

                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault()) > 0;
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            string sp = StoreProcedures["DeleteUser"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                bool result = false;
                if (result_query != null && result_query.Any())
                {

                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault()) > 0;
                }

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region GET

        public async Task<Form> GetFormById(int id)
        {
            string sp = StoreProcedures["GetFormById"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                Form result = null;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Form.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FormQuestion> GetFormQuestionById(int id)
        {
            string sp = StoreProcedures["GetFormQuestionById"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                FormQuestion result = null;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.FormQuestion.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<FormQuestion>> GetFormQuestions_by_Form(int formId)
        {
            string sp = StoreProcedures["GetFormQuestions_by_Form"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fformid", formId, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                IEnumerable<FormQuestion> result = null;
                if (result_query != null && result_query.Any())
                {
                    result = from row in result_query
                             select (FormQuestion)Mapper.FormQuestion.Map(row);
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Form>> GetForms()
        {
            string sp = StoreProcedures["GetForms"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                IEnumerable<Form> result = null;
                if (result_query != null && result_query.Any())
                {
                    result = from row in result_query
                             select (Form)Mapper.Form.Map(row);
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Person> GetPersonById(int id)
        {
            string sp = StoreProcedures["GetPersonById"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                Person result = null;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Person.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Person>> GetPersonByUserId(int userId)
        {
            string sp = StoreProcedures["GetPersonByUserId"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", userId, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                IEnumerable<Person> result = null;
                if (result_query != null && result_query.Any())
                {
                    result = from row in result_query
                             select (Person)Mapper.Person.Map(row);
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Question> GetQuestionById(int id)
        {
            string sp = StoreProcedures["GetQuestionById"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                Question result = null;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Question.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            string sp = StoreProcedures["GetQuestions"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                IEnumerable<Question> result = null;
                if (result_query != null && result_query.Any())
                {
                    result = from row in result_query
                             select (Question)Mapper.Question.Map(row);
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<QuestionType> GetQuestionTypeById(int id)
        {
            string sp = StoreProcedures["GetQuestionTypeById"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                QuestionType result = null;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.QuestionType.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<QuestionType>> GetQuestionTypes()
        {
            string sp = StoreProcedures["GetQuestionTypes"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                IEnumerable<QuestionType> result = null;
                if (result_query != null && result_query.Any())
                {
                    result = from row in result_query
                             select (QuestionType)Mapper.QuestionType.Map(row);
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<QuestionValue> GetQuestionValueById(int id)
        {
            string sp = StoreProcedures["GetQuestionValueById"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                QuestionValue result = null;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.QuestionValue.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<QuestionValue>> GetQuestionValues_by_Question(int questionId)
        {
            string sp = StoreProcedures["GetQuestionValues_by_Question"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fquestionid", questionId, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                IEnumerable<QuestionValue> result = null;
                if (result_query != null && result_query.Any())
                {
                    result = from row in result_query
                             select (QuestionValue)Mapper.QuestionValue.Map(row);
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText }");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            string sp = StoreProcedures["GetUserById"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", id, DbType.Int32);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                User result = null;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.User.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUserByUid(Guid uid)
        {
            string sp = StoreProcedures["GetUserByUid"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fuid", uid, DbType.Guid);
                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                User result = null;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.User.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Update

        public async Task<int> UpdateForm(Form form)
        {
            string sp = StoreProcedures["UpdateForm"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", form.ID, DbType.Int32);
                parameters.Add("fname", form.Name, DbType.String);
                parameters.Add("fdescription", form.Description, DbType.String);
                parameters.Add("factive", form.Active, DbType.Boolean);

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateFormQuestion(FormQuestion formQuestion)
        {
            string sp = StoreProcedures["UpdateFormQuestion"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", formQuestion.ID, DbType.Int32);
                parameters.Add("fformid", formQuestion.FormID, DbType.Int32);
                parameters.Add("fquestionid", formQuestion.QuestionID, DbType.Int32);
                parameters.Add("forder", formQuestion.Order, DbType.Int32);
                parameters.Add("fnext", formQuestion.Next, DbType.Int32);
                parameters.Add("falternativenext", formQuestion.AlternativeNext, DbType.Int32);

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdatePerson(Person person)
        {
            string sp = StoreProcedures["UpdatePerson"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", person.ID, DbType.Int32);
                parameters.Add("fuserid", person.UserID, DbType.Int32);
                parameters.Add("freference", person.Reference, DbType.String);

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateQuestion(Question question)
        {
            string sp = StoreProcedures["UpdateQuestion"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", question.ID, DbType.Int32);
                parameters.Add("ftypeid", question.QuestionTypeID, DbType.Int32);
                parameters.Add("fname", question.Name, DbType.String);
                parameters.Add("fquestion", question.Description, DbType.String);
                

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateQuestionType(QuestionType questionType)
        {
            string sp = StoreProcedures["UpdateQuestionType"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", questionType.ID, DbType.Int32);                
                parameters.Add("fname", questionType.Name, DbType.String);
                parameters.Add("fdescription", questionType.Description, DbType.String);


                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateQuestionValue(QuestionValue questionValue)
        {
            string sp = StoreProcedures["UpdateQuestionValue"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", questionValue.ID, DbType.Int32);
                parameters.Add("fquestionid", questionValue.QuestionID, DbType.Int32);
                parameters.Add("fname", questionValue.Name, DbType.String);
                parameters.Add("fdescription", questionValue.Description, DbType.String);
                parameters.Add("fvalue", questionValue.Value, DbType.Int32);


                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateUser(User user)
        {
            string sp = StoreProcedures["UpdateUser"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fid", user.ID, DbType.Int32);
                parameters.Add("fuid", user.UID, DbType.Guid);
                parameters.Add("fusername", user.Username, DbType.String);

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Insert

        public async Task<int> InsertForm(Form form)
        {
            string sp = StoreProcedures["InsertForm"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fname", form.Name, DbType.String);
                parameters.Add("fdescription", form.Description, DbType.String);
                parameters.Add("factive", form.Active, DbType.Boolean);

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertFormQuestion(FormQuestion formQuestion)
        {
            string sp = StoreProcedures["InsertFormQuestion"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fformid", formQuestion.FormID, DbType.Int32);
                parameters.Add("fquestionid", formQuestion.QuestionID, DbType.Int32);
                parameters.Add("forder", formQuestion.Order, DbType.Int32);
                parameters.Add("fnext", formQuestion.Next, DbType.Int32);
                parameters.Add("falternativenext", formQuestion.AlternativeNext, DbType.Int32);


                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertPerson(Person person)
        {
            string sp = StoreProcedures["InsertPerson"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fuserid", person.UserID, DbType.Int32);
                parameters.Add("freference", person.Reference, DbType.String);

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertQuestion(Question question)
        {
            string sp = StoreProcedures["InsertQuestion"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("ftypeid", question.QuestionTypeID, DbType.Int32);
                parameters.Add("fname", question.Name, DbType.String);
                parameters.Add("fquestion", question.Description, DbType.String);

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertQuestionType(QuestionType questionType)
        {
            string sp = StoreProcedures["InsertQuestionType"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fname", questionType.Name, DbType.String);
                parameters.Add("fdescription", questionType.Description, DbType.String);


                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertQuestionValue(QuestionValue questionValue)
        {
            string sp = StoreProcedures["InsertQuestionValue"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fquestionid", questionValue.QuestionID, DbType.Int32);
                parameters.Add("fname", questionValue.Name, DbType.String);
                parameters.Add("fdescription", questionValue.Description, DbType.String);
                parameters.Add("fvalue", questionValue.Value, DbType.Int32);


                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertUser(User user)
        {
            string sp = StoreProcedures["InsertUser"];
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("fuid", user.UID, DbType.Guid);
                parameters.Add("fusername", user.Username, DbType.String);

                var result_query = await _connection.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);
                int result = 0;
                if (result_query != null && result_query.Any())
                {
                    result = Mapper.Primitive<int>.Map(result_query.FirstOrDefault());
                }

                return result;
            }
            catch (Npgsql.PostgresException ex)
            {
                throw new Npgsql.NpgsqlException($"Error with database code: {ex.SqlState} msg: {ex.MessageText}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
