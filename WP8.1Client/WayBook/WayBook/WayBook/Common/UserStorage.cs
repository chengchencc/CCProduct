﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using PCLStorage.Exceptions;

namespace WayBook.Common
{
    public class UserStorage
    {
        public static async Task<string> ReadTextFromFile(string fileName)
        {
            try
            {
                var folder = FileSystem.Current.LocalStorage;
                var file = await folder.GetFileAsync(fileName);
                if (file != null)
                {
                    return await file.ReadAllTextAsync();
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("UserStorage.ReadTextFromFile", ex);
            }
            return String.Empty;
        }

        public static async Task WriteText(string fileName, string content)
        {
            try
            {
                var folder = FileSystem.Current.LocalStorage;
                var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                await file.WriteAllTextAsync(content);
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("UserStorage.WriteText", ex);
            }
        }

        public static async Task DeleteFileIfExists(string fileName)
        {
            try
            {
                var folder = FileSystem.Current.LocalStorage;
                var file = await folder.GetFileAsync(fileName);
                if (file != null)
                {
                    await file.DeleteAsync();
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("UserStorage.DeleteFileIfExists", ex);
            }
        }

        public static async Task AppendLineToFile(string fileName, string line)
        {
            try
            {
                var folder = FileSystem.Current.LocalStorage;
                var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                string old = await file.ReadAllTextAsync();
                await file.WriteAllTextAsync(old + Environment.NewLine + line);
            }
            catch { /* Avoid any exception at this point. */ }
        }
    }
}
