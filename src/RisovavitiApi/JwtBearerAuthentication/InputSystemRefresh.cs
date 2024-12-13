﻿using DomainModel.Model;
using DomainModel.ResultsRequest;
using Logic.Interface;
using RisovavitiApi.JwtBearerAuthentication.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class InputSystemRefresh : IInputerSystem
	{
		IAdderSessionByRefresh AdderSession { get; set; }
		IGetterSessionByRefresh GetterSession { get; set; }

		public InputSystemRefresh(IAdderSessionByRefresh adder, IGetterSessionByRefresh getter) 
		{
			AdderSession = adder;
			GetterSession = getter;
		}

		public string InputUser(User user)
		{
			return AdderSession.AddSession(UserResult.CreateResultFromUser(user), "Да");
		}
	}
}
