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

var scoreP1 = 0;
var scoreP2 = 0;

foreach (var row in ReadFileMatrix<char>(args[0], ' ').Select(row => row.ToArray()))
{
    switch (row[0])
    {
        case 'A' when row[1] == 'X':
            scoreP1 += draw + rock;
            scoreP2 += loss + scissors;
            break;
        case 'A' when row[1] == 'Y':
            scoreP1 += win + paper;
            scoreP2 += draw + rock;
            break;
        case 'A' when row[1] == 'Z':
            scoreP1 += loss + scissors;
            scoreP2 += win + paper;
            break;
        case 'B' when row[1] == 'X':
            scoreP1 += loss + rock;
            scoreP2 += loss + rock;
            break;
        case 'B' when row[1] == 'Y':
            scoreP1 += draw + paper;
            scoreP2 += draw + paper;
            break;
        case 'B' when row[1] == 'Z':
            scoreP1 += win + scissors;
            scoreP2 += win + scissors;
            break;
        case 'C' when row[1] == 'X':
            scoreP1 += win + rock;
            scoreP2 += loss + paper;
            break;
        case 'C' when row[1] == 'Y':
            scoreP1 += loss + paper;
            scoreP2 += draw + scissors;
            break;
        case 'C' when row[1] == 'Z':
            scoreP1 += draw + scissors;
            scoreP2 += win + rock;
            break;
    }
}

Console.WriteLine($"(Part 1) Final score: {scoreP1}\n" +
                  $"(Part 2) Final score: {scoreP2}");
