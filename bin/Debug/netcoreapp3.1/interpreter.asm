BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
fltOutput: db "%f", 0
DAT0: db "", 0
DAT1: db "Expected: 5", 0
DAT2: db "", 0
DAT3: db "Expected: 7,541592", 0
DAT4: db "Expected: 2.3", 0
DAT5: db "Expected: 4,6017", 0
DAT6: db "Expected: 13,823", 0
DAT7: db "Expected: 6,0", 0
DAT8: db "Expected: 8,0", 0
DAT9: db "Expected: 27,0", 0
DAT10: db "Expected: 12,0", 0
DAT11: db "Expected: 3,0", 0
DAT12: db "Expected: 15,0", 0
DAT13: db "Expected: 5,0", 0
DAT14: db "Expected: 14,0", 0
DAT15: db "Expected: 42,0", 0
DAT16: db "Expected: 30,0", 0
DAT17: db "Expected: 17,0", 0
DAT18: db "c= ", 0
DAT19: db "Expected: 1", 0
DAT20: db "t= ", 0
DAT21: db "Expected: -30", 0
DAT22: db "d= ", 0
DAT23: db "Expected: 2", 0
DAT24: db "g= ", 0
DAT25: db "Expected: -1", 0
DAT26: db "w= ", 0
DAT27: db "Expected: -4", 0
DAT28: db "Result: ", 0
DAT29: db "Expected: 10", 0
DAT30: db "Expected: 22", 0
DAT31: db "Expected: 12", 0
DAT32: db "Expected: 18", 0
DAT33: db "c<d", 0
DAT34: db "Expected: false", 0
DAT35: db "c==d", 0
DAT36: db "else", 0
DAT37: db "Expected: true", 0
i: dd 0
p: dd 0
a: dd 0
s: dd 0
d: dd 0
m: dd 0
t: dd 0
c: dd 0
z: dd 0
v: dd 0
g: dd 0
w: dd 0
flt0 : dd 3.141592
flt1 : dd 4.4
flt2 : dd 2.1
flt3 : dd 5.2
flt4 : dd 1.13
flt5 : dd 2.0
flt6 : dd 3.0
flt7 : dd 7.0
flt8 : dd 4.0
flt9 : dd 10.0
flt10 : dd 5.0
flt11 : dd 1.0
flt12 : dd 6.0
flt13 : dd 15.0
flt14 : dd 8.0
flt15 : dd 14.0

section .text
global _main
extern _printf
extern _scanf
_main:
finit

xor eax, eax
xor ebx, ebx
xor ecx, ecx
xor edx, edx

mov eax, 5
mov [i], eax

push dword DAT0
push dword DAT2
call _printf
add esp, 4

mov eax, [i]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos0

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con0

pos0:
push eax
push dword positiv
call _printf
add esp, 8

con0:

push dword ns
call _printf
add esp, 4

push dword DAT1
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt0]
fstp dword [p]

fld dword [flt1]
fld dword [p]
fadd

fstp dword [a]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[a]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT3
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt1]
fld dword [flt2]
fsub

fstp dword [s]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[s]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT4
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt3]
fld dword [flt4]
fdiv

fstp dword [d]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[d]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT5
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt1]
fld dword [p]
fmul

fstp dword [m]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[m]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT6
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt5]
fld dword [flt5]
fadd

fld dword [flt5]
fadd

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT7
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt5]
fld dword [flt5]
fmul

fld dword [flt5]
fmul

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT8
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt6]
fld dword [flt6]
fmul

fld dword [flt6]
fmul

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT9
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt6]
fld dword [flt6]
fld dword [flt6]
fmul

fadd

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT10
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt7]
fld dword [flt8]
fsub

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT11
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt9]
fld dword [flt10]
fadd

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT12
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt7]
fld dword [flt6]
fsub

fld dword [flt5]
fadd

fld dword [flt11]
fsub

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT13
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt9]
fld dword [flt11]
fadd

fld dword [flt5]
fadd

fld dword [flt6]
fsub

fld dword [flt8]
fadd

fld dword [flt12]
fadd

fld dword [flt13]
fsub

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT13
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt7]
fld dword [flt8]
fmul

fld dword [flt5]
fdiv

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT14
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt7]
fld dword [flt8]
fmul

fld dword [flt5]
fdiv

fld dword [flt6]
fmul

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT15
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt9]
fld dword [flt8]
fmul

fld dword [flt5]
fmul

fld dword [flt6]
fmul

fld dword [flt14]
fdiv

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT16
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt5]
fld dword [flt7]
fld dword [flt8]
fmul

fadd

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT16
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt7]
fld dword [flt14]
fld dword [flt8]
fdiv

fsub

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT13
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

fld dword [flt15]
fld dword [flt5]
fld dword [flt6]
fmul

fadd

fld dword [flt12]
fld dword [flt5]
fdiv

fsub

fstp dword [t]

push dword DAT0
push dword DAT2
call _printf
add esp, 4

fld dword[t]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

push dword DAT17
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 1
mov [c], eax

push dword DAT18
call _printf
add esp, 4

mov eax, [c]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos1

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con1

pos1:
push eax
push dword positiv
call _printf
add esp, 8

con1:

push dword ns
call _printf
add esp, 4

push dword DAT19
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 12
push eax
mov ebx, 14
pop eax
add eax, ebx

push eax
mov ebx, 41
pop eax
sub eax, ebx

push eax
mov ebx, 2
pop eax
mul ebx

mov [z], eax

push dword DAT20
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos2

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con2

pos2:
push eax
push dword positiv
call _printf
add esp, 8

con2:

push dword ns
call _printf
add esp, 4

push dword DAT21
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 4
push eax
mov ebx, 2
pop eax
mov edx, 0
mov ecx, ebx
div ecx

mov [v], eax

mov eax, 0
push eax
mov ebx, 1
pop eax
sub eax, ebx

mov [g], eax

mov eax, 0
push eax
mov ebx, 1
pop eax
sub eax, ebx

push eax
mov ebx, 1
pop eax
sub eax, ebx

push eax
mov ebx, 1
pop eax
sub eax, ebx

push eax
mov ebx, 1
pop eax
sub eax, ebx

mov [w], eax

push dword DAT22
call _printf
add esp, 4

mov eax, [v]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos3

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con3

pos3:
push eax
push dword positiv
call _printf
add esp, 8

con3:

push dword ns
call _printf
add esp, 4

push dword DAT23
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT24
call _printf
add esp, 4

mov eax, [g]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos4

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con4

pos4:
push eax
push dword positiv
call _printf
add esp, 8

con4:

push dword ns
call _printf
add esp, 4

push dword DAT25
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT26
call _printf
add esp, 4

mov eax, [w]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos5

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con5

pos5:
push eax
push dword positiv
call _printf
add esp, 8

con5:

push dword ns
call _printf
add esp, 4

push dword DAT27
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 7
push eax
mov eax, 3
push eax
mov eax, 10
push eax
mov eax, 12
push eax
mov eax, 3
push eax
mov ebx, 1
pop eax
add eax, ebx

mov ebx, eax
pop eax
mov edx, 0
mov ecx, ebx
div ecx

push eax
mov ebx, 1
pop eax
sub eax, ebx

mov ebx, eax
pop eax
mov edx, 0
mov ecx, ebx
div ecx

mov ebx, eax
pop eax
mul ebx

push eax
mov eax, 2
push eax
mov ebx, 3
pop eax
add eax, ebx

mov ebx, eax
pop eax
mov edx, 0
mov ecx, ebx
div ecx

mov ebx, eax
pop eax
add eax, ebx

push eax
mov ebx, 5
pop eax
sub eax, ebx

push eax
mov ebx, 3
pop eax
sub eax, ebx

push eax
mov ebx, 8
pop eax
add eax, ebx

mov [z], eax

push dword DAT28
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos6

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con6

pos6:
push eax
push dword positiv
call _printf
add esp, 8

con6:

push dword ns
call _printf
add esp, 4

push dword DAT29
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 7
push eax
mov eax, 3
push eax
mov eax, 10
push eax
mov eax, 12
push eax
mov eax, 3
push eax
mov ebx, 1
pop eax
add eax, ebx

mov ebx, eax
pop eax
mov edx, 0
mov ecx, ebx
div ecx

push eax
mov ebx, 1
pop eax
sub eax, ebx

mov ebx, eax
pop eax
mov edx, 0
mov ecx, ebx
div ecx

mov ebx, eax
pop eax
mul ebx

mov ebx, eax
pop eax
add eax, ebx

mov [g], eax

push dword DAT28
call _printf
add esp, 4

mov eax, [g]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos7

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con7

pos7:
push eax
push dword positiv
call _printf
add esp, 8

con7:

push dword ns
call _printf
add esp, 4

push dword DAT30
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 7
push eax
mov eax, 3
push eax
mov ebx, 2
pop eax
add eax, ebx

mov ebx, eax
pop eax
add eax, ebx

mov [c], eax

push dword DAT28
call _printf
add esp, 4

mov eax, [c]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos8

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con8

pos8:
push eax
push dword positiv
call _printf
add esp, 8

con8:

push dword ns
call _printf
add esp, 4

push dword DAT31
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 6
mov [c], eax

mov eax, 5
mov [v], eax

mov eax, [c]
push eax
mov ebx, 1
pop eax
add eax, ebx

push eax
mov ebx, 2
pop eax
add eax, ebx

push eax
mov ebx, 2
pop eax
mul ebx

mov [c], eax

push dword DAT28
call _printf
add esp, 4

mov eax, [c]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos9

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp con9

pos9:
push eax
push dword positiv
call _printf
add esp, 8

con9:

push dword ns
call _printf
add esp, 4

push dword DAT32
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, [v]
push eax
mov ebx, 1
pop eax
add eax, ebx

push eax
mov ebx, 2
pop eax
add eax, ebx

push eax
mov ebx, 2
pop eax
mul ebx

mov ebx, eax
push ebx

mov eax, [c]
pop ebx

cmp eax, ebx
jl cjl10
jmp con10

cjl10:
push dword DAT33
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT34
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

jmp cnt0

con10:
mov eax, [d]
mov ebx, eax
push ebx

mov eax, [c]
pop ebx

cmp eax, ebx
je cje11
jmp con11

cje11:
push dword DAT35
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT34
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

jmp cnt0

con11:
push dword DAT36
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT37
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

cnt0:
ret 0
