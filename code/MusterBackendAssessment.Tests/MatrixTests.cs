using Xunit;
using MusterBackendAssessment;
using Shouldly;

namespace MusterBackendAssessment.Tests;

public class MatrixTests {
    [Fact]
    public void Parsing_Matrix_Works() {
        var matrix = Matrix.Parse(@"1,2,3
4,5,6
7,8,9");
        var expected = new int[,] { { 1,2,3}, {4,5,6}, {7,8,9}};        
        matrix.Contents.ShouldBe(expected);
    }

    [Fact]
    public void Transpose_Matrix_Works() {
        var matrix = Matrix.Parse(@"1,2,3
4,5,6
7,8,9");
        var transpose = matrix.Transpose();
        var expected = new int[,] { { 9,8,7}, {6,5,4}, {3,2,1}};
        transpose.Contents.ShouldBe(expected);
    }

    [Fact]
    public void Matrix_ToString_Works() {
        var input = @"1,2,3
4,5,6
7,9,9";
        var matrix = Matrix.Parse(input);
        var output = matrix.ToString();
        output.ShouldBe(input);
    }

    [Fact]
    public void One_Equals_One() {
        var input = 1;
        var expected = 1;
        input.ShouldBe(expected);
    }
}