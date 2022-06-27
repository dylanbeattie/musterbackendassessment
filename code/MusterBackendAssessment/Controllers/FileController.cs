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

namespace MusterBackendAssessment.Controllers {
    [Route("/")]
    [ApiController]
    public class FileController : ControllerBase {
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
        // //write logic here
        //                         var matrix = Matrix.Parse(str);
        //                         var flat = matrix.Flatten();
        //                         return Ok(flat.ToString());
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

        public async Task<IActionResult> Invert(IFormFile file) {
            try {
                if (CheckIfFileIsValid(file)) {
                    // var inputString = await ReadAsStringAsync(file);
                    // var matrix = Matrix.parse(str);
                    // var inverse = matrix.Invert();
                    // var result = inverse.ToString();
                    // var matrix = stringToMatrix(inputString);
                    // var inverted = invertMatrix(matrix);
                    // var result = matrixToString(inverted);
                    return Ok();
                } else {
                    return BadRequest("Invalid file format, please enter a .csv file");
                }
            } catch (Exception ex) {
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
        public async Task<IActionResult> Echo(IFormFile file) {
            try {
                if (CheckIfFileIsValid(file)) {
                    var str = await ReadAsStringAsync(file);
                    return Ok(str);
                } else {
                    return BadRequest("Invalid file format, please enter a .csv file");
                }
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }




        /// <summary>
        /// Reads the content of the file into a string variable 
        /// </summary>
        /// <param name="file">The file to be read</param>
        /// <returns>A string whose value is the content of the file</returns>
        public static async Task<string> ReadAsStringAsync(IFormFile file) {
            if (file == null || file.Length == 0) return null;
            using (var reader = new StreamReader(file.OpenReadStream())) {
                return await reader.ReadToEndAsync();
            }
        }


        /// <summary>
        /// Checks if the file is not null and has a valid extension
        /// </summary>
        /// <param name="file">The file to be checked </param>
        /// <returns>A boolean for whether the file is valid or otherwise </returns>
        private bool CheckIfFileIsValid(IFormFile file) {
            if (file == null) //Break if file is null
            {
                throw new FileNotFoundException("File cannot be null, please upload a file");
            } else {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                return extension == ".csv";
            }

        }

        private int[,] stringToMatrix(string input) {
            /* TODO: turn input string "1,2,3\n4,5,6\n7,8,9" into
            a 2D array [ 
                1, 2, 3,
                4, 5, 6,
                7, 8, 9
            ]
            */
            return new int[,] { 
                { 11, 22, 33 },
                { 44, 55, 66 },
                { 77, 88, 99 }
            };
        }

        private int[,] invertMatrix(int[,] matrix) {
            return new int[,] { 
                { 111, 222, 333 },
                { 444, 555, 666 },
                { 777, 888, 999 }
            };
        }
        private string matrixToString(int[,] matrix) {
            return "Hello!";
        }
    }
}
