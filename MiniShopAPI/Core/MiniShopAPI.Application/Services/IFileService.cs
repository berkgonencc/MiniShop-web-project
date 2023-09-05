﻿using System;
using Microsoft.AspNetCore.Http;

namespace MiniShopAPI.Application.Services
{
	public interface IFileService
	{
		Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);
		Task<string> FileRenameAsync(string fileName);
		Task<bool> CopyFileAsync(string path, IFormFile file);

	}
}

