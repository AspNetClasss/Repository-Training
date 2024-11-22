using HomeTrainingRepository.Models.DomainModels;
using HomeTrainingRepository.Models.FrameWorks.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HomeTrainingRepository.Models.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _context;

        #region -Ctor-
        public PersonRepository(ProjectDbContext context)
        {
            _context = context;
        } 
        #endregion

        #region -Select-
        public async Task<List<Person>> Select()
        {
            using (_context)
            {
                try
                {

                    var persons = await _context.Person.ToListAsync();
                    return persons;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }

            }
        } 
        #endregion

        #region -Insert-
        public async Task Insert(Person person)

        {
            using (_context)
            {
                try
                {
                    var p = new Person()
                    {
                        Id = Guid.NewGuid(),
                        FName = person.FName,
                        LName = person.LName,
                    };


                    _context.Add(p);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }

            }
        } 
        #endregion

        #region -Update-
        public async Task Update(Person person)
        {
            using (_context)
            {


                try
                {
                    var p = _context.Update(person);

                    //var p = await _context.Person.FindAsync(person);
                    //_context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }
            }
        } 
        #endregion

        #region -Delete-
        public async Task Delete(Person person)
        {
            try
            {


                var p = _context.Remove(person);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            finally
            {
                if (_context.Person != null) _context.Dispose();
            }
        }
        #endregion

      
    }
}
    
     
    
