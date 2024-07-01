using Microsoft.JSInterop;
using Web_Centi_Payments_Reports.Components.Entities;

namespace Web_Centi_Payments_Reports.Components.XLS;

public class Excel
{
    public async Task GenerarClienteXLStAsync(IJSRuntime js, List<ClienteInfo> data, string filename = "export.xlsx")
    {
        var cliente = new ClienteXLS();
        var XLSStream = cliente.Edition(data);
        await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
    }

    //public async Task TemplateWeatherForecastAsync(IJSRuntime js, Stream streamTemplate, ClienteInfo[] data, string filename = "export.xlsx")
    //{
    //    var templateXLS = new UseTemplateXLS();
	//	var XLSStream = templateXLS.Edition(streamTemplate, data);
    //
    //    await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
    //}
    //
    //public async Task TemplateOnExistingFileAsync(HttpClient client, IJSRuntime js, Stream streamTemplate, ClienteInfo[] data, string existingFile)
    //{
    //    var templateXLS = new UseTemplateXLS();
    //    var XLSStream = await templateXLS.FillIn(client, streamTemplate, data, existingFile);
    //    
    //    await js.InvokeVoidAsync("BlazorDownloadFile", "export.xlsx", XLSStream);
    //}
}
