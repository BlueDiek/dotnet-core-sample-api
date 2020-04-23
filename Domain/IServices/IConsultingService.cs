using Consulting.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Domain.IService
{
    public interface IConsultingService
    {
        #region USER
        Task<int> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<int> InsertUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUid(Guid uid);
        #endregion

        #region PERSON
        Task<int> UpdatePerson(Person person);
        Task<bool> DeletePerson(int id);
        Task<int> InsertPerson(Person person);
        Task<Person> GetPersonById(int id);
        Task<IEnumerable<Person>> GetPersonByUserId(int userId);
        #endregion

        #region FORM
        Task<int> UpdateForm(Form form);
        Task<bool> DeleteForm(int id);
        Task<int> InsertForm(Form form);
        Task<Form> GetFormById(int id);
        Task<IEnumerable<Form>> GetForms();
        #endregion

        #region QUESTION_TYPE
        Task<int> UpdateQuestionType(QuestionType questionType);
        Task<bool> DeleteQuestionType(int id);
        Task<int> InsertQuestionType(QuestionType questionType);
        Task<QuestionType> GetQuestionTypeById(int id);
        Task<IEnumerable<QuestionType>> GetQuestionTypes();
        #endregion

        #region QUESTION
        Task<int> UpdateQuestion(Question question);
        Task<bool> DeleteQuestion(int id);
        Task<int> InsertQuestion(Question question);
        Task<Question> GetQuestionById(int id);
        Task<IEnumerable<Question>> GetQuestions();
        #endregion

        #region QUESTION VALUE
        Task<int> UpdateQuestionValue(QuestionValue questionValue);
        Task<bool> DeleteQuestionValue(int id);
        Task<int> InsertQuestionValue(QuestionValue questionValue);
        Task<QuestionValue> GetQuestionValueById(int id);
        Task<IEnumerable<QuestionValue>> GetQuestionValues_by_Question(int questionId);
        #endregion

        #region FORM QUESTION
        Task<int> UpdateFormQuestion(FormQuestion formQuestion);
        Task<bool> DeleteFormQuestion(int id);
        Task<int> InsertFormQuestion(FormQuestion formQuestion);
        Task<FormQuestion> GetFormQuestionById(int id);
        Task<IEnumerable<FormQuestion>> GetFormQuestions_by_Form(int formId);

        #endregion


    }
}