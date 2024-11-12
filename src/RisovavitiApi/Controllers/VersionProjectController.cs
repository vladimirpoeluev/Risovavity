﻿using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.UserOperate;

namespace RisovavitiApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class VersionProjectController : Controller
	{
		IFabricOperateVersionProject _operate;

		public VersionProjectController(IFabricOperateVersionProject operate) 
		{
			_operate = operate;
		}

		[HttpGet("get/{id}")]
		public async Task<IActionResult> Get(int id) 
		{
			try
			{
				return await TryGetById(id);
			}
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}

		async Task<OkObjectResult> TryGetById(int id) 
		{
			var getter = _operate.CreateGetter(UserGetterByContext.GetUserIntegration(HttpContext));
			var vertion = await getter.GetVersionProjectByIdAsync(id);
			return Ok(vertion);
		}

		[HttpGet("get")]
		public async Task<IActionResult> Get(int skip, int take)
		{
			var getter = _operate.CreateGetter(UserGetterByContext.GetUserIntegration(HttpContext));
			var versions = await getter.GetVersionProjectsAsync(skip, take);
			return Ok(versions);
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromBody] VersionProjectForAddResult result)
		{
			var adder = _operate.CreateAdder(UserGetterByContext.GetUserIntegration(HttpContext));
			await adder.AddVertionProjectAsync(result);
			return Ok();
		}

		[HttpPost("delet/{id}")]
		public async Task<IActionResult> Delet(int id)
		{
			var adder = _operate.CreateAdder(UserGetterByContext.GetUserIntegration(HttpContext));
			await adder.DeleteVertionProjectAsync(id);
			return Ok();
		}
	}
}