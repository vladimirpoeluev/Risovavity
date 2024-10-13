﻿using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.EntranceController
{
	internal class RegistrationController : PostControllerIntegration<RegistrationForm>, IRegistraionController
	{
		public RegistrationController(IAuthenticationUser user) : base(user, new RegistrationForm())
		{
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest("api/Entrance/regist");
		}

		void IRegistraionController.RegistrationSystem(RegistrationForm form)
		{
			Value = form;
			CheckStatusCode(GetResponseMessage());
		}
	}
}