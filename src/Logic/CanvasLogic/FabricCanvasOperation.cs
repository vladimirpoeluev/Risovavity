﻿using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using Logic.Interface;

namespace Logic.CanvasLogic
{
	public class FabricCanvasOperation : IFabricCanvasOperation
	{
		DatabaseContext _db;
		public FabricCanvasOperation(DatabaseContext db)
		{
			_db = db;
		}

		public IAdderCanvas CreateAdderCanvas(UserResult user)
		{
			return new AdderCanvas(user, _db);
		}

		public IEditerCanvas CreateEditerCanvas(UserResult user)
		{
			return new EditerCanvas(_db);
		}

		public IGetterCanvas CreateGetterCanvas(UserResult user)
		{
			return new GetterCanvas(_db, user);
		}
	}
}
