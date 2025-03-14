using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services.Interface;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services
{
    internal class GetterDraftProject : IGetterDraftProject
	{
		public static string Path = "projects";


		public async Task<DraftModel> GetDraftModel(Guid guid)
		{
			if (!Directory.Exists($"{Path}/{guid}"))
				throw new Exception();
			DraftModel info = new DraftModel();
			
			using FileStream reader = new FileStream($"{Path}/{guid}/image", FileMode.Open);
			await reader.ReadAsync(info.Images);

			using StreamReader readerJson = new StreamReader($"{Path}/{guid}/info.json");
			ConvertDraftInfo(await readerJson.ReadToEndAsync());
			return info;
		}

		private DraftInfo ConvertDraftInfo(string json)
		{
			DraftInfo info = JsonConvert.DeserializeObject<DraftInfo>(json) ?? new DraftInfo();
			return info;
		}

		public Task<Guid> GetGuids()
		{
			throw new NotImplementedException();
		}

		public Task OpenForEdit(Guid guid)
		{
			throw new NotImplementedException();
		}
	}
}
