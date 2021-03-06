﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliWebSearchStatisticApp.Utils.HttpSearchQueriers
{
	public interface IHttpQuerier
	{
		Task<string> QueryBySearchKeywordAsync(string search);
	}
}
