﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote.Services
{
	public class NoteService
	{
		private readonly Guid _userId;

		public NoteService(Guid userId)
		{
			_userId = userId;
		}
	}
}
