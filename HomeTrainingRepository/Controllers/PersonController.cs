using HomeTrainingRepository.Models.DomainModels;
using HomeTrainingRepository.Models.FrameWorks.Contracts;
using HomeTrainingRepository.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;

namespace HomeTrainingRepository.Controllers
{
    public class PersonController : Controller

    {
        private readonly IPersonRepository _personRepository;

        #region [-Ctor-]
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        } 
        #endregion

        #region [-Index-]
        public async Task<IActionResult> Index()
        {
            var persons = await _personRepository.Select();
            return View(persons);
        } 
        #endregion

        #region [-Create-]

        public IActionResult Create()
        {
            return View();
        } 
        #endregion

        #region [-CreatePost-]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FName,LName")] Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepository.Insert(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        } 
        #endregion

        #region [-Edit-]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var p = await _personRepository.Select(id);


            return View(p);
        } 
        #endregion

        #region [-EditPost-]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FName,LName")] Person person)
        {


            if (ModelState.IsValid)
            {
                await _personRepository.Update(person);
            }
        
            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region [-Delete-]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var p = await _personRepository.Select(id);


            return View(p);
        } 
        #endregion

        #region [-DeletePost-]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Person person)
        {
            if (person == null)
            {
                return NotFound();
            }

            await _personRepository.Delete(person);


            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region [-Details-]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var p = await _personRepository.Select(id);
            return View(p);
        } 
        #endregion

    }

}

