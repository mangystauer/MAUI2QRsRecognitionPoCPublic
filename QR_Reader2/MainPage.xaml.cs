using Android.App;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace QR_Reader2;

public partial class MainPage : ContentPage
{

    string _result;
    
    public MainPage()
    {
        InitializeComponent();

        barcodeReader.Options= new BarcodeReaderOptions { 
        Formats = BarcodeFormats.TwoDimensional,
        AutoRotate= true,
        Multiple = true   
        };

    }




private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            string result = "";
            foreach (var barcode in e.Results)
            {
                result += $" {barcode.Value.ToString()}";
            }

            _result= result;
            barcodeResult1.Text = _result;
            //barcodeResult2.Text = $"{e.Results[1].Value} ";
        });
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        _result = "";
        barcodeResult1.Text = _result;
    }
}

