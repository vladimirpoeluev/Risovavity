﻿using DomainModel.ResultsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveApiRisovaviti.Interface
{
	internal interface IAvatarUsersControllerIntegration
	{
		UserAvatarResult GetAvatarResult(int id);
	}
}