using static CommonLib.CommonLib;

/*
 * Scoring
 *  Match result
 *      Win = 6
 *      Draw = 3
 *      Loss = 0
 *  Column 1
 *      A = rock
 *      B = paper
 *      C = scissors
 *  Column 2
 *      Part 1
 *          X = rock = 1 point
 *          Y = paper = 2 points
 *          Z = scissors = 3 points
 *      Part 2
 *          X = loss
 *          Y = draw
 *          Z = win
 */

const int rock = 1;
const int paper = 2;
const int scissors = 3;
const int loss = 0;
const int draw = 3;
const int win = 6;

var scoreV1 = 0;
var scoreV2 = 0;

foreach (var row in ReadFileMatrix<char>(args[0], ' ').Select(row => row.ToArray()))
{
    if (row[0] == 'A' && row[1] == 'X') 
    {
        scoreV1 += draw + rock;
        scoreV2 += loss + scissors;
    }

    if (row[0] == 'A' && row[1] == 'Y') 
    {
        scoreV1 += win + paper;
        scoreV2 += draw + rock;
    }

    if (row[0] == 'A' && row[1] == 'Z') 
    {
        scoreV1 += loss + scissors;
        scoreV2 += win + paper;
    }

    if (row[0] == 'B' && row[1] == 'X') 
    {
        scoreV1 += loss + rock;
        scoreV2 += loss + rock;
    }

    if (row[0] == 'B' && row[1] == 'Y') 
    {
        scoreV1 += draw + paper;
        scoreV2 += draw + paper;
    }

    if (row[0] == 'B' && row[1] == 'Z') 
    {
        scoreV1 += win + scissors;
        scoreV2 += win + scissors;
    }

    if (row[0] == 'C' && row[1] == 'X') 
    {
        scoreV1 += win + rock;
        scoreV2 += loss + paper;
    }

    if (row[0] == 'C' && row[1] == 'Y') 
    {
        scoreV1 += loss + paper;
        scoreV2 += draw + scissors;
    }

    if (row[0] == 'C' && row[1] == 'Z') 
    {
        scoreV1 += draw + scissors;
        scoreV2 += win + rock;
    }
}

Console.WriteLine($"(Part 1) Final score: {scoreV1}\n" +
                  $"(Part 2) Final score: {scoreV2}");
