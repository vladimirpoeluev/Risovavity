using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services.Interface;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services
{
    internal class AdderNewProject : IAdderNewProject
	{
		public static string Path = "projects";
		public AdderNewProject() { }

		public async Task<Guid> AddProject(DraftModel draft)
		{
			var path = Path + $"/{draft.Guid}";
			AddDirect(path);
			using (FileStream writer = new FileStream(path + "/image", FileMode.OpenOrCreate))
			{
				await writer.WriteAsync(draft.Images);
			}

			using StreamWriter writerJson = new StreamWriter(path + "/info.json");
			await writerJson.WriteAsync(ObjectConvert(draft.DraftInfo));

			return draft.Guid;
		}

		private void AddDirect(string path)
		{
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
		}

		private string ObjectConvert(DraftInfo obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

	}
}
