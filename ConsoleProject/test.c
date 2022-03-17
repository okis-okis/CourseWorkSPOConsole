int main(){
	int i;
	int t;

	scanf("%d", t);

	int c = 5+t;		//5
	int d = c+11;		//16
	int g = (5-2)*10;	//30
	i = 5+10 + (g-d)*c;	//85
	
	printf("c = %d", c);
	printf("d = %d", d);
	printf("g = %d", g);
	printf("i = %d", i);
	printf("t = %d", t);

	return 0;
}