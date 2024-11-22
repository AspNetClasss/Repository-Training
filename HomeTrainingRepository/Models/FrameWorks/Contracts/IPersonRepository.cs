using HomeTrainingRepository.Models.DomainModels;

namespace HomeTrainingRepository.Models.FrameWorks.Contracts
{
    public interface IPersonRepository
    {
        Task<List<Person>> Select();
        Task Insert(Person person);
        Task Update(Person person);
        Task Delete(Person person);


    }

}
