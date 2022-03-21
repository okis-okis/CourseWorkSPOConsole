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

</code>

Output:
<code>
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
</code>
