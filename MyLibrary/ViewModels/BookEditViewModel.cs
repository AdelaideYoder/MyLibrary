﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibrary.Data;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.ViewModels
{
    public class BookEditViewModel
    {
        public Book Book { get; set; }

        public List<SelectListItem> Libraries { get; set; }

        //Used this in the Get Method
        public BookEditViewModel(ApplicationDbContext context)
        {
            Libraries = context.Library.Select(library =>
            new SelectListItem { Text = library.Name, Value = library.LibraryId.ToString() }).ToList();
        }

        //Created this constructor to re-display the form with submitted values already populated in form
        //Used this in the POST method for Edit
        public BookEditViewModel(ApplicationDbContext context, Book book)
        {
            Libraries = context.Library.Select(library =>
            new SelectListItem { Text = library.Name, Value = library.LibraryId.ToString() }).ToList();
            Book = book;
        }
    }
}
