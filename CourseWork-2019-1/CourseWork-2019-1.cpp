#include <iostream>

// The point of this program is to find if a certain point is in a rectangle in a coordinate system
// In this example in the main function, there are already defined some rectangle, but you can add more or new ones
// When you define them with their 4 points for each rectangle, in the console as input you type two numbers a x and y for
// a point and the programs finds if is in the some rectangle


struct Point
{
	int x;
	int y;
};
struct Region
{
	int x;
	int y;
	int w;
	int h;
};

void SetTheRegion(Region& region, int x, int y, int w, int h)
{

	region.x = x;
	region.y = y;
	region.w = w;
	region.h = h;
}
void FoundInAnyRegion(Region* array, Point point, int sizeOfArray)
{
	bool FoundAnywhere = false;
	for (int i = 0; i < sizeOfArray; i++)
	{
		Region currentRegion = array[i];
		int pX = point.x;
		int pY = point.y;
		int regSX = currentRegion.x;
		int regSY = currentRegion.y;
		int regEX = currentRegion.w + regSX;
		int regEY = regSY - currentRegion.h;

		if ((pX > regSX && pX < regEX) && (pY < regSY && pY > regEY))
		{
			printf("The point (%d, %d) is found in the %dst region (%d, %d, %d, %d)\n",
				pX, pY, i + 1, regSX, regSY, regEX, regEY);
			FoundAnywhere = true;
		}
	}
	if (!FoundAnywhere)
	{
		printf("The point (%d, %d) isn't found anywhere :(\n", point.x, point.y);
	}
}


int main()
{
	Region region1;
	Region region2;
	Region region3;

	SetTheRegion(region1, -9, 6, 8, 9);
	SetTheRegion(region2, -7, 7, 17, 5);
	SetTheRegion(region3, 2, -2, 7, 5);

	Region array[3] = { region1, region2, region3 };

	Point point;

	printf("Give 2 integer numbers (x, y) for the point.\n");
	scanf_s("%d", &point.x);
	scanf_s("%d", &point.y);

	FoundInAnyRegion(array, point, 3);
}

