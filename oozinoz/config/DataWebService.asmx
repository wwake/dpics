<%@ WebService Language="c#" Class="DataWebService" %>
using System;
using System.Web.Services;
using DataLayer;
using Fireworks;
[WebService(Namespace="http://localhost/webservices/")]
public class DataWebService
{
	[WebMethod]
	public Rocket RocketHome(string name)
	{
		return (Rocket) DataServices.Find(
			typeof(Rocket), name);
	}
}