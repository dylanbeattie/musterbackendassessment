using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterBackendAssessment.Controllers
{
    [Route("/")]
    [ApiController]
    public class FileController : ControllerBase
    {
        // public async Task<IActionResult> Flatten(IFormFile file) 
        //         {

        //         }
        // public async Task<IActionResult> Sum(IFormFile file) 
        // {

        // }
        // public async Task<IActionResult> Multiply(IFormFile file) 
        // {

        // }
        /// <summary>
        /// Return the matrix as a string in matrix format where the columns and rows are inverted. 
        /// </summary>
        /// <param name="file">The file to process</param>
        /// <returns>The matrix as a string in matrix format where the columns and rows are inverted.</returns>
        [AllowAnonymous]
        [HttpPost("invert")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Invert(IFormFile file) 
        {
            // Console.WriteLine("Hello World");
            try
            {
                if (CheckIfFileIsValid(file))
                {
                    using (StreamReader sr = new StreamReader((Stream)file))
                    {
                        string strResult = await sr.ReadToEndAsync();
                        string[] results = strResult.Split(Environment.NewLine.ToArray(),StringSplitOptions.RemoveEmptyEntries);
                    }

                    List<string[]> matrixArray = new List<string[]>();
                    foreach (string result in results)
                    {
                        matrixArray.Add(result.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                    }

                    int iColumnNumber = 0;
                    int iRowNumber = 0;

                    iColumnNumber = 3;
                    iRowNumber = 3;
                    

                        //     for (int rowIndex = 0; 
                        //     rowIndex <= (matrixArray.GetUpperBound(0)); rowIndex++)
                        // {

                        //     for (int colIndex = 0; 
                        //     colIndex <= (matrixArray.GetUpperBound(1) / 2); colIndex++)
                        //     {
                        //         int tempHolder = matrixArray[rowIndex, colIndex];                        
                        //         matrixArray[rowIndex, colIndex] = 
                        //         matrixArray[rowIndex, matrixArray.GetUpperBound(1) - colIndex];   
                        //         matrixArray[rowIndex, matrixArray.GetUpperBound(1) - colIndex] = 
                        //         tempHolder;      
                        //     }
                        // }
                        // {
                        //     char[,] result = new char[file.GetLength(0), file.GetLength(1)]; 
                        //     //Create a result array that is the same length as the file array
                        //     for (int x = 0; x < file.GetLength(0); ++x) //Iterate through the horizontal rows of the two dimensional array
                        //     {
                        //         for (int y = 0; y < file.GetLength(1); ++y) //Iterate throught the vertical rows, to add more dimensions add another for loop for z
                        //         {
                        //             result[x, y] = file[x, y]; //Change result x,y to file x,y
                        //         }
                        //     }
                        //     return result;
        
                        // }
                        // return Ok(str);

                }
                    else
                {
                    return BadRequest("Invalid file format, please enter a .csv file");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         }

        /// <summary>
        /// Return the matrix as a string in matrix format. Please note that this endpoint does not check the validity of
        /// the content of the file, only its extension and its value.
        /// </summary>
        /// <param name="file">The file to process</param>
        /// <returns>The matrix as a string in matrix format.</returns>
        [AllowAnonymous]
        [HttpPost("echo")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Echo(IFormFile file) 
        {
            try
            {
                if (CheckIfFileIsValid(file))
                {
                    var str = await ReadAsStringAsync(file);
                    return Ok(str);
                }
                else
                {
                    return BadRequest("Invalid file format, please enter a .csv file");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
       

        /// <summary>
        /// Reads the content of the file into a string variable 
        /// </summary>
        /// <param name="file">The file to be read</param>
        /// <returns>A string whose value is the content of the file</returns>
        public static async Task<string> ReadAsStringAsync( IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return await Task.FromResult((string)null);
                }

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks if the file is not null and has a valid extension
        /// </summary>
        /// <param name="file">The file to be checked </param>
        /// <returns>A boolean for whether the file is valid or otherwise </returns>
        private bool CheckIfFileIsValid(IFormFile file)
        {
            if (file == null) //Break if file is null
            {
                throw new FileNotFoundException("File cannot be null, please upload a file");
            }
            else
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                return extension == ".csv";
            }
           
        }

    }
}
