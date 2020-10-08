﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFE.Model.Fabric;
using AFE.Service.Data.Repositories.Interfaces;
using AFE.Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AFE.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MLInputFBController : ControllerBase
    {
		private readonly IMLInputFBRepository _mlInputFBRepository;
		private readonly MLModelBuilder _mlModelBuilder;


		public MLInputFBController(IMLInputFBRepository mlInputFBRepository, MLModelBuilder mlModelBuilder)
		{
			_mlInputFBRepository = mlInputFBRepository;
			_mlModelBuilder = mlModelBuilder;
		}

		[HttpPost("all")]
		public IActionResult TransferToMLInput()
		{
			return Ok(_mlInputFBRepository.TransferToMLInput());
		}

		[HttpPost("confirm")]
		public IActionResult ConfirmFeeback([FromBody] FeedbackModel model)
		{
			_mlInputFBRepository.ConfirmFeeback(model.Id, model.ConfirmedSentiment);

			return Ok();
		}

		[HttpPost("retrain")]
		public IActionResult RetrainTheMachine()
		{
			Task.Run(() => _mlModelBuilder.InitSQL());

			return Ok();
		}
	}
}