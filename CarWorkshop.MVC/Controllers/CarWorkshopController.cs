﻿using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers;

public class CarWorkshopController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CarWorkshopController(IMediator mediator, IMapper mapper)
    {

        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var allWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
        return View(allWorkshops);
    }
    public IActionResult Create()
    {
        return View();
    }

    [Route("CarWorkshop/{encodedName}/Details")]
    public async Task<IActionResult> Details(string encodedName)
    {
        var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));


        return View(dto);
    }

    [Route("CarWorkshop/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
        EditCarWorkshopCommand model = _mapper.Map<EditCarWorkshopCommand>(dto);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("CarWorkshop/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(EditCarWorkshopCommand command,string encodedName)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

}
