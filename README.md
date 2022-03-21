# CourseWorkSPOConsole
Hello everyone!I am building a simple interpreter for C language. So, project wirted on C#. Main idea i get from Ruslan Spivak blog 

Link: https://ruslanspivak.com/lsbasi-part1/

## Simple C code for test

### Test 1
<code>
  int main(){
	
	int c = 1;				//1
	printf("c= %d", c);
	int t = (12+14-41)*2;	//-30
	printf("t= %d", t);
	int d= 4/2;				//2
	int g = -1;
	int w = -1-1-1-1;		//-4
	printf("d= %d", d);
	printf("g= %d", g);
	printf("w= %d", w);
	t = 7 + 3 * (10 / (12 / (3 + 1) - 1)) / (2 + 3) - 5 - 3 + (8);	//10
	printf("Result: %d", t);
	g = 7 + 3 * (10 / (12 / (3 + 1) - 1));	//22
	c = 7 + (((3 + 2)));	//12
	printf("Result: %d", g);
	printf("Result: %d", c);

	return 0;
}
</code>

Output:
<code>
  
</code>

### Test 2
<code>
int main(){
	int c = 6;
	int d = 5;
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
</code>

### This section  is editing...

