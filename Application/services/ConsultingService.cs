using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consulting.Domain.IRepository;
using Consulting.Domain.IService;
using Consulting.Domain.Models;
using Consulting.Domain.Models.Entities;

namespace Consulting.Application.Services
{
    public class ConsultingService : IConsultingService
    {
        private readonly IConsultingRepository _consultingRepository;

        public ConsultingService(IConsultingRepository consultingRepository)
        {
            _consultingRepository = consultingRepository ?? throw new ArgumentNullException(nameof(consultingRepository));
        }

        #region DELETE

        public async Task<bool> DeleteForm(int id)
        {
            return await _consultingRepository.DeleteForm(id);
        }

        public async Task<bool> DeleteFormQuestion(int id)
        {
            return await _consultingRepository.DeleteFormQuestion(id);
        }

        public async Task<bool> DeletePerson(int id)
        {
            return await _consultingRepository.DeletePerson(id);
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            return await _consultingRepository.DeleteQuestion(id);
        }

        public async Task<bool> DeleteQuestionType(int id)
        {
            return await _consultingRepository.DeleteQuestionType(id);
        }

        public async Task<bool> DeleteQuestionValue(int id)
        {
            return await _consultingRepository.DeleteQuestionValue(id);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _consultingRepository.DeleteUser(id);
        }

        #endregion
        #region GET
        public async Task<Form> GetFormById(int id)
        {
            return await _consultingRepository.GetFormById(id);
        }

        public async Task<FormQuestion> GetFormQuestionById(int id)
        {
            return await _consultingRepository.GetFormQuestionById(id);
        }

        public async Task<IEnumerable<FormQuestion>> GetFormQuestions_by_Form(int formId)
        {
            return await _consultingRepository.GetFormQuestions_by_Form(formId);
        }

        public async Task<IEnumerable<Form>> GetForms()
        {
            return await _consultingRepository.GetForms();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _consultingRepository.GetPersonById(id);
        }

        public async Task<IEnumerable<Person>> GetPersonByUserId(int userId)
        {
            return await _consultingRepository.GetPersonByUserId(userId);
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _consultingRepository.GetQuestionById(id);
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _consultingRepository.GetQuestions();
        }

        public async Task<QuestionType> GetQuestionTypeById(int id)
        {
            return await _consultingRepository.GetQuestionTypeById(id);
        }

        public async Task<IEnumerable<QuestionType>> GetQuestionTypes()
        {
            return await _consultingRepository.GetQuestionTypes();
        }

        public async Task<QuestionValue> GetQuestionValueById(int id)
        {
            return await _consultingRepository.GetQuestionValueById(id);
        }

        public async Task<IEnumerable<QuestionValue>> GetQuestionValues_by_Question(int questionId)
        {
            return await _consultingRepository.GetQuestionValues_by_Question(questionId);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _consultingRepository.GetUserById(id);
        }
        public async Task<User> GetUserByUid(Guid uid)
        {
            return await _consultingRepository.GetUserByUid(uid);
        }

        #endregion
        #region Update
        public async Task<int> UpdateForm(Form form)
        {
            return await _consultingRepository.UpdateForm(form);
        }

        public async Task<int> UpdateFormQuestion(FormQuestion formQuestion)
        {
            return await _consultingRepository.UpdateFormQuestion(formQuestion);
        }

        public async Task<int> UpdatePerson(Person person)
        {
            return await _consultingRepository.UpdatePerson(person);
        }

        public async Task<int> UpdateQuestion(Question question)
        {
            return await _consultingRepository.UpdateQuestion(question);
        }

        public async Task<int> UpdateQuestionType(QuestionType questionType)
        {
            return await _consultingRepository.UpdateQuestionType(questionType);
        }

        public async Task<int> UpdateQuestionValue(QuestionValue questionValue)
        {
            return await _consultingRepository.UpdateQuestionValue(questionValue);
        }

        public async Task<int> UpdateUser(User user)
        {
            return await _consultingRepository.UpdateUser(user);
        }
        #endregion
        #region Insert

        public async Task<int> InsertForm(Form form)
        {
            return await _consultingRepository.InsertForm(form);
        }

        public async Task<int> InsertFormQuestion(FormQuestion formQuestion)
        {
            return await _consultingRepository.InsertFormQuestion(formQuestion);
        }

        public async Task<int> InsertPerson(Person person)
        {
            return await _consultingRepository.InsertPerson(person);
        }

        public async Task<int> InsertQuestion(Question question)
        {
            return await _consultingRepository.InsertQuestion(question);
        }

        public async Task<int> InsertQuestionType(QuestionType questionType)
        {
            return await _consultingRepository.InsertQuestionType(questionType);
        }

        public async Task<int> InsertQuestionValue(QuestionValue questionValue)
        {
            return await _consultingRepository.InsertQuestionValue(questionValue);
        }

        public async Task<int> InsertUser(User user)
        {
            return await _consultingRepository.InsertUser(user);
        }
        #endregion
    }
}
