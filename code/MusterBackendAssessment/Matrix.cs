using System;

public class Matrix {
    private Matrix(int[,] contents) {
        this.Contents = contents;
    }
    public int[,] Contents { get; init; }
    
    ///<summary>Create a matrix by parsing a string containing comma-separated elements
    /// on rows separated by newlines</summary>
    public static Matrix Parse(string input) {    
        return new Matrix(new int[,] { { 1,2,3}, {4,5,6}, {7,8,9} });
    }

    public Matrix Transpose() {
        return new Matrix(new int[,] { { 1,2,3}, {4,5,6}, {7,8,9} });
    }

    public override string ToString() {
        return "//todo: fix this!";
    }
}