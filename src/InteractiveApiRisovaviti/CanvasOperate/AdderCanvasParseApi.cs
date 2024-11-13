﻿using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class AdderCanvasParseApi : IAdderCanvas
	{
		IAuthenticationUser _user;
		FabricAutoControllerIntegraion _operate;

		public AdderCanvasParseApi(IAuthenticationUser user) 
		{
			_user = user;
			_operate = new CreaterAuthoControllersIntegraion();
		}

		public Task AddCanvas(CanvasAddResult canvasAddResult)
		{
			var operate = _operate.CreatePostPatser(_user, canvasAddResult);
			operate.ExecuteReques("api/canvas/add");
			return Task.CompletedTask;
		}
	}
}
