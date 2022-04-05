# Onyx
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

### Test 2
	int main(){
	//int i = 4/2;
	int i=5;
	
	printf("%d", i);
	printf("Expected: 5");
	
	float p = 3.141592;
	
	float a = 4.4+p;
	printf("%f", a);
	printf("Expected: 7,541592");
	
	float s = 4.4-2.1;
	printf("%f", s);
	printf("Expected: 2.3");
	
	float d = 5.2/1.13;
	printf("%f", d);
	printf("Expected: 4,6017");
	
	float m = 4.4*p;
	printf("%f", m);
	printf("Expected: 13,823");
	
	float t = 2.0+2.0+2.0;
	printf("%f", t);
	printf("Expected: 6,0");
	
	t = 2.0*2.0*2.0;
	printf("%f", t);
	printf("Expected: 8,0");
	
	t = 3.0*3.0*3.0;
	printf("%f", t);
	printf("Expected: 27,0");
	
	t = 3.0+3.0*3.0;
	printf("%f", t);
	printf("Expected: 12,0");
	
	t = 7.0 - 4.0;
	printf("%f", t);
	printf("Expected: 3,0");
	
	t = 10.0 + 5.0;
	printf("%f", t);
	printf("Expected: 15,0");
	
	t = 7.0 - 3.0 + 2.0 - 1.0;
	printf("%f", t);
	printf("Expected: 5,0");
	
	t = 10.0 + 1.0 + 2.0 - 3.0 + 4.0 + 6.0 - 15.0;
	printf("%f", t);
	printf("Expected: 5,0");
		
	t = 7.0 * 4.0 / 2.0;
	printf("%f", t);
	printf("Expected: 14,0");
	
	t = 7.0 * 4.0 / 2.0 * 3.0;
	printf("%f", t);
	printf("Expected: 42,0");
	
	t = 10.0 * 4.0  * 2.0 * 3.0 / 8.0;
	printf("%f", t);
	printf("Expected: 30,0");
	
	t = 2.0 + 7.0 * 4.0;
	printf("%f", t);
	printf("Expected: 30,0");
	
	t = 7.0 - 8.0 / 4.0;
	printf("%f", t);
	printf("Expected: 5,0");
	
	t = 14.0 + 2.0 * 3.0 - 6.0 / 2.0;
	printf("%f", t);
	printf("Expected: 17,0");
	
	int c = 1;				//1
	printf("c= %d", c);
	printf("Expected: 1");
	
	int z = (12+14-41)*2;	//-30
	printf("t= %d", z);
	printf("Expected: -30");
	
	int v= 4/2;				//2
	int g = -1;
	int w = -1-1-1-1;		//-4
	
	printf("d= %d", v);
	printf("Expected: 2");
	
	printf("g= %d", g);
	printf("Expected: -1");
	
	printf("w= %d", w);
	printf("Expected: -4");
	
	z = 7 + 3 * (10 / (12 / (3 + 1) - 1)) / (2 + 3) - 5 - 3 + (8);	//10
	printf("Result: %d", z);
	printf("Expected: 10");
	
	g = 7 + 3 * (10 / (12 / (3 + 1) - 1));	//22
	printf("Result: %d", g);
	printf("Expected: 22");
	
	c = 7 + (((3 + 2)));	//12
	printf("Result: %d", c);
	printf("Expected: 12");
	
	c = 6;
	v = 5;
	c = (c+1+2)*2;
	printf("Result: %d", c);
	printf("Expected: 18");
	
	if (c < (v+1+2)*2) {
		printf("c<d");
		printf("Expected: false");
	}
	else if (c == d) {
		printf("c==d");
		printf("Expected: false");
	}
	else {
		printf("else");
		printf("Expected: true");
	}
	
	return 0;
	}
Output

	5
	Expected: 5
	7.541592
	Expected: 7,541592
	2.300000
	Expected: 2.3
	4.601770
	Expected: 4,6017
	13.823006
	Expected: 13,823
	6.000000
	Expected: 6,0
	8.000000
	Expected: 8,0
	27.000000
	Expected: 27,0
	12.000000
	Expected: 12,0
	3.000000
	Expected: 3,0
	15.000000
	Expected: 15,0
	5.000000
	Expected: 5,0
	5.000000
	Expected: 5,0
	14.000000
	Expected: 14,0
	42.000000
	Expected: 42,0
	30.000000
	Expected: 30,0
	30.000000
	Expected: 30,0
	5.000000
	Expected: 5,0
	17.000000
	Expected: 17,0
	c= 1
	Expected: 1
	t= -30
	Expected: -30
	d= 2
	Expected: 2
	g= -1
	Expected: -1
	w= -4
	Expected: -4
	Result: 10
	Expected: 10
	Result: 22
	Expected: 22
	Result: 12
	Expected: 12
	Result: 18
	Expected: 18
	else
	Expected: true

## Test 3

	int main(){
	
	bool t = true AND false;
	printf("%i", t);
	bool r = true AND true;
	printf("%i", r);
	
	bool z = true AND true AND true;
	printf("%i", z);
	
	z = true AND false AND true;
	printf("%i", z);
	
	z = true OR false;
	printf("%i", z);
	
	z = true OR true;
	printf("%i", z);
	
	z = false OR false;
	printf("%i", z);
	
	z = false OR false OR false;
	printf("%i", z);
	
	z = true OR false OR false;
	printf("%i", z);
	
	z = (true AND (true OR false) AND (true AND true)) OR false;
	printf("%i", z);
	
	z = NOT(true);
	printf("%i", z);
	
	z = NOT(false);
	printf("%i", z);
	
	t = true;
	z = NOT(NOT(false));
	printf("%i", z);
	
	return 0;
	}
	
Output:

	0
	1
	1
	0
	1
	1
	0
	0
	1
	1
	0
	1
	0

## Test 4

	int main(){
	
	int i;
	
	for(i=0;i<10;i = i+1){
		printf("%i", i);
	}
	return 0;
	}

Output:

	0
	1
	2
	3
	4
	5
	6
	7
	8
	9
