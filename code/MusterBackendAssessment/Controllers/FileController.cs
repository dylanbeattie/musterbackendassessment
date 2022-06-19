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
        // [AllowAnonymous]
        // [HttpPost("flatten")]
        // [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        // public async Task<IActionResult> Flatten(IFormFile file) 
        //         {
        //             try
        //             {
        //                 if (CheckIfFileIsValid(file))
        //                 {
        //                     var str = await ReadAsStringAsync(file);
                            //write logic here
        //                     return Ok(str);
        //                 }
        //                 else
        //                 {
        //                     return BadRequest("Invalid file format, please enter a .csv file");
        //                 }
        //             }
        //             catch (Exception ex)
        //             {
        //                 return BadRequest(ex.Message);
        //             }

        //         }

        // [AllowAnonymous]
        // [HttpPost("sum")]
        // [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        // public async Task<IActionResult> Sum(IFormFile file) 
        // {
        //     try
            // {
                // if (CheckIfFileIsValid(file))
                // {
                //     var str = await ReadAsStringAsync(file);
                //Write logic here
                //     return Ok(str);
                // }
                // else
                // {
                //     return BadRequest("Invalid file format, please enter a .csv file");
                // }
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }

        // }

        // [AllowAnonymous]
        // [HttpPost("multiply")]
        // [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        // public async Task<IActionResult> Multiply(IFormFile file) 
        // {
        //     try
        //     {
                // if (CheckIfFileIsValid(file))
                // {
                //     var str = await ReadAsStringAsync(file);
                //write logic here
                //     return Ok(str);
                // }
                // else
                // {
                //     return BadRequest("Invalid file format, please enter a .csv file");
                // }
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }

        // }
        private IEnumerable<string> strResult;

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
                        var str = await ReadAsStringAsync(file);
                        string[] result = str.Split(Environment.NewLine.ToCharArray()
                            ,StringSplitOptions.RemoveEmptyEntries
                            );

                        // foreach (char item in str)
                        // {
                        //     result.Add(str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                        // }

                    // foreach (char result in str)
                    // {
                    //     matrixArray.Add(result.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                    // }


                        char[,] matrixArray = new char[result.GetLength(0), result.GetLength(1)]; 
                         //Create a matrix array that is the same length as the file array

                    
                            for (int rowIndex = 0; 
                             rowIndex <= (matrixArray.GetUpperBound(0)); rowIndex++)
                             //Iterate through the horizontal rows of the two dimensional array
                            {

                                for (int colIndex = 0; 
                                colIndex <= (matrixArray.GetUpperBound(1) / 2); colIndex++)
                                //Iterate throught the vertical rows, to add more dimensions add another for loop for z
                                {
                                    int tempHolder = matrixArray[rowIndex, colIndex];                        
                                    matrixArray[rowIndex, colIndex] = 
                                    matrixArray[rowIndex, matrixArray.GetUpperBound(1) - colIndex];   
                                    matrixArray[rowIndex, matrixArray.GetUpperBound(1) - colIndex] =
                                    (char)tempHolder;      
                                }
                            }
                            Console.WriteLine(matrixArray);

                        return Ok(matrixArray);

                    // List<string[]> matrixArray = new List<string[]>();
                    // foreach (char result in str)
                    // {
                    //     matrixArray.Add(result.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                    // }

                    // return Ok(matrixArray);

                    // int iColumnNumber = 0;
                    // int iRowNumber = 0;

                    // iColumnNumber = 3;
                    // iRowNumber = 3;
                    

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
