using RestSharp;

var con = new HubSpotConnection();
con.ProcessAutomationTickets();

public class HubSpotConnection
{
	private RestClient client;

	private const string Token = ""; //This token you get in private apps in hubspot admin panel

	public void ProcessAutomationTickets()
	{
		client = new RestClient("https://api.hubapi.com");
		client.AddDefaultHeader("Authorization", $"Bearer {Token}");

		var request = new RestRequest("/crm/v3/objects/companies");
		var taskResponse = client.GetAsync(request);
		taskResponse.Wait();
		var result = taskResponse.Result;
	}
}

