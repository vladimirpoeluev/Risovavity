using Avalonia.Controls;
using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services
{
    internal class GetterDraftProject : IGetterDraftProject
	{
		public static string Path = "projects";


		public async Task<DraftModel> GetDraftModel(Guid guid)
		{
			return await GetDraftModel(guid, "image");
		}
		public async Task<DraftModel> GetDraftModel(Guid guid, string filename)
		{
			if (!Directory.Exists($"{Path}/{guid}"))
				throw new Exception();
			DraftModel info = new DraftModel();
			info.Guid = guid;
			using FileStream reader = new FileStream($"{Path}/{guid}/{filename}", FileMode.Open);
			info.Images = new byte[reader.Length];
			await reader.ReadAsync(info.Images);

			using StreamReader readerJson = new StreamReader($"{Path}/{guid}/info.json");
			ConvertDraftInfo(await readerJson.ReadToEndAsync());
			return info;
		}

		public async Task<IEnumerable<string>> GetImagesByProject(Guid guid)
		{
			return Directory.EnumerateFiles($"{Path}/{guid}", "image*").Where(str => str != "info.json").Select(str => str.Replace($"{Path}/{guid}\\", string.Empty));
		}

		private DraftInfo ConvertDraftInfo(string json)
		{
			DraftInfo info = JsonConvert.DeserializeObject<DraftInfo>(json) ?? new DraftInfo();
			return info;
		}

		public async Task<IEnumerable<Guid>> GetGuids()
		{
			IEnumerable<string> dir = Directory.GetDirectories(Path).Select((str) => new string(str.Skip(9).ToArray()));
			return dir.Select(str => new Guid(str)).ToList();
		}
		

		public void OpenForEdit(Guid guid)
		{
			OpenForEdit(guid, "image");
		}

		public void OpenForEdit(Guid guid, string nameImage)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = Environment.CurrentDirectory + @$"\{Path}\{guid}\{nameImage}",
				UseShellExecute = true
			});
		}
	}
}
