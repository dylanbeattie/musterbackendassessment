using System;

public class Matrix {
    private Matrix(int[,] contents) {
        this.Contents = contents;
    }
    public int[,] Contents { get; init; }
    
    ///<summary>Create a matrix by parsing a string containing comma-separated elements
    /// on rows separated by newlines</summary>
    public static Matrix Parse(string input) {    
        // TODO: instead of hard-coding the matrix,
        // you need to split the string input into lines,
        // split each line into tokens (numbers), parse each number
        // into an integer, and then construct a new matrix using
        // that set of numbers.
        return new Matrix(new int[,] { { 1,1}, {2,2} });
    }

    public Matrix Transpose() {
        // TODO: Return a new matrix whose contents
        // are the transpose of the current matrix.
        return new Matrix(new int[,] { { 1,1,1}, {2,2,2}, {3,3,3} });
    }
    public override string ToString() {
        return "//todo: return this matrix as a string :)";
    }
}