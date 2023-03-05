#include <utility>
#include <iostream>
using namespace std;

int main()
{
    int a = 50;
    int b = 25;
    cout << "a: " << a << ", b: " << b << endl;

    swap(a, b);
    cout << "a: " << a << ", b: " << b << endl;

    for (size_t x = 6; x > 0; --x)
    {
        for (size_t y = 0; y < x-1; ++y)
        {
            cout << "$_";
        }
        cout << "$\n";
    }
    return 0;
}