
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using losol.EventManagement.Domain;
using losol.EventManagement.Services;
using losol.EventManagement.Services.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace losol.EventManagement.Web.Api.Controllers
{
	[Route("api/v0/events")]
	[ApiController]
	public class EventsController : Controller
	{
		private readonly IEventInfoService _eventsService;

		public EventsController(IEventInfoService eventsService)
		{
			_eventsService = eventsService;
		}


		// GET: api/v0/events
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var events = await _eventsService.GetEventsAsync();
			var list = events.Select(s => new
			{
				Id = s.EventInfoId,
				s.Title,
				s.Description,
				s.Location,
				s.City,
				s.DateStart,
				s.DateEnd,
				s.FeaturedImageUrl
			});
			return Ok(list);
		}

	}
}