# CourseWorkSPOConsole
Hello everyone!I am building a simple interpreter for C language. I used C# for write project. Main idea i get from Ruslan Spivak blog. I used IDE VS 2022. Version .NET Core is 3.1. Project developed for Windows and Linux.

Link: https://ruslanspivak.com/lsbasi-part1/

## Compilation
For compile of this project on Linux use commands:

<code>	mcs Interpreter.cs Node.cs Token.cs TokenTypes.cs Lexer.cs Parser.cs Program.cs && mono Interpreter.exe test.c </code>

## Simple C code for test

### Test 1
	int main(){
		int c = 1;		//1
		printf("c= %d", c);
		int t = (12+14-41)*2;	//-30
		printf("t= %d", t);
		int d= 4/2;		//2
		int g = -1;
		int w = -1-1-1-1;	//-4
		printf("d= %d", d);
		printf("g= %d", g);
		printf("w= %d", w);
		t = 7 + 3 * (10 / (12 / (3 + 1) - 1)) / (2 + 3) - 5 - 3 + (8);	//10
		printf("Result: %d", t);
		g = 7 + 3 * (10 / (12 / (3 + 1) - 1));	//22
		c = 7 + (((3 + 2)));	//12
		printf("Result: %d", g);
		printf("Result: %d", c);

		c = 6;
		d = 5;
		c = (c+1+2)*2;
		printf("Result: %d", c);
		if (c < (d+1+2)*2) {
			printf("c<d");
		}
		else if (c == d) {
			printf("c==d");
		}
		else {
			printf("else");
		}

	return 0;
	}

Output:

	c= 1
	t= -30
	d= 2
	g= -1
	w= -4
	Result: 10
	Result: 22
	Result: 12
	Result: 18
	else
