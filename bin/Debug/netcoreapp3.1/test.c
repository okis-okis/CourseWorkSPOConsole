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
