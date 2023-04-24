#include <iostream>
#include <istream>
#include <stdlib.h>
#include <time.h>

using namespace::std;

const int boardSize = 3;
char cells[boardSize][boardSize];
char symbol;
int row;
int col;
int emptyCells = boardSize*boardSize;
bool playerTurn = true;

void DrawBoard()
{
    for (row = 0; row < boardSize; row++)
    {
        cout << (row > 0 ? "-----" : "") << endl;
        for (col = 0; col < boardSize; col++)
        {
            if (col < boardSize - 1) 
            {
                cout << (cells[col][row] == '\0' ? ' ' : cells[col][row]) << "|";
            }
            else cout << cells[col][row];
        }
        cout << endl;
    }
}

bool TrySetSymbol(int x, int y, char symbolChar)
{
    if (cells[x][y] != 0) return false;
    cells[x][y] = symbolChar;
    emptyCells--;
    return true;
}

void PlayerTurn()
{
    symbol = 'X';
AskFromPlayer:
    cout << "In what column do you want to place your X (1-3)?" << endl;
    cin >> col;
    col -= 1;
    if (col > -1 && col < boardSize)
    {
        cout << "In what row do you want to place your X (1-3)?" << endl;
        cin >> row;
        row -= 1;
        if (row > -1 && row < boardSize)
        {
            if (TrySetSymbol(col, row, symbol)) return;
            cout << "Please choose an empty cell!" << endl;
            goto AskFromPlayer;
        }
    }
    cout << "Please choose between 1-3!" << endl;
    goto AskFromPlayer;
}

void AiTurn()
{
    symbol = 'O';
ChooseAgain:
    srand(time(0));
    col = rand() %boardSize;
    row = rand() %boardSize;
    if (TrySetSymbol(col, row, symbol)) return;
    goto ChooseAgain;
}

bool GameWon(int col, int row)
{
    for (int x = 0; x < boardSize; x++)
    {
        if (cells[x][row] != symbol) break;
        if (x == boardSize - 1) return true;
    }
    for (int y = 0; y < boardSize; y++)
    {
        if (cells[col][y] != symbol) break;
        if (y == boardSize - 1) return true;
    }
    for (int i = 0; i < boardSize; i++)
    {
        if (cells[i][i] != symbol) break;
        if (i == boardSize - 1) return true;
    }
    for (int i = 0; i < boardSize; i++)
    {
        if (cells[boardSize - i - 1][i] != symbol) break;
        if (i == boardSize - 1) return true;
    }
    return false;
}

int main()
{
    cout << "Welcome to Tic - Tac - Toe!" << endl
         << "Player symbol : X" << endl
         << "AI symbol : O" << endl;

    bool gameWon;
    while (true)
    {
        DrawBoard();
        playerTurn ? PlayerTurn() : AiTurn();
        system("CLS");
        playerTurn = !playerTurn;
        gameWon = GameWon(col, row);
        if (gameWon || emptyCells == 0) break;
    }
    DrawBoard();
    if (!gameWon) cout << "Game over" << endl;
    else cout << symbol << " won!" << endl;
}