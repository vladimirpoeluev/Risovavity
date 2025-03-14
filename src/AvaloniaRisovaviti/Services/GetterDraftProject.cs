using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

		public async Task<IEnumerable<Guid>> GetGuids()
		{
			return Directory.GetDirectories(Path).Select(str => new Guid(str)).ToList();
		}

		public void OpenForEdit(Guid guid)
		{
			Process.Start(new ProcessStartInfo($"{Path}/{guid}/image"));
		}
	}
}
