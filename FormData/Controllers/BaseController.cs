using System;
using System.Web.Mvc;
using AutoMapper;
using FormData.DataLayer;
using FormData.Models;


//created new class-controller that will run before Customer Cinntroller
namespace FormData.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper Mapper;

        protected BaseController()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Customer, CustomerEdit>();

            });
            Mapper = config.CreateMapper();
        }
    }
}