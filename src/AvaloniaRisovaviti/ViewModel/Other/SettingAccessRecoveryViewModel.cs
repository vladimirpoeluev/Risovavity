using Avalonia.Media;
using AvaloniaRisovaviti.ProfileShows;
using DomainModel.ResultsRequest.TotpModels;
using InteractiveApiRisovaviti.Interface.Topt;
using QRCoder;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaRisovaviti.ViewModel.Other
{
	public class SettingAccessRecoveryViewModel : BaseViewModel
	{
		[Reactive]
		public TotpKeysResult Keys { get; set; }
		[Reactive]
		public IImage QRCode { get; set; }

		IGetterTotp getterTotp;

		public SettingAccessRecoveryViewModel(IGetterTotp getterTotp)
		{
			this.getterTotp = getterTotp;
			Keys = new TotpKeysResult();
			Keys.TotpKeysForQR = "https://github.com/MikeCodesDotNET/Avalonia-QRCode";
		}

		public override async void Load()
		{
			TryActionAsync(async () =>
			{
				Keys = await getterTotp.GetKey();
				using var qrGenerator = new QRCodeGenerator();
				using var qrCodeData = qrGenerator.CreateQrCode(Keys.TotpKeysForQR, QRCodeGenerator.ECCLevel.H);
				using var qr = new BitmapByteQRCode(qrCodeData);
				QRCode = ImageAvaloniaConverter.ConvertByteInImage(qr.GetGraphic(20));
			});
			base.Load();
		}
	}
}
