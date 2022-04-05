BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
fltOutput: db "%f", 0
DAT0: db "", 0
DAT1: db "", 0
DAT2: db "", 0
DAT3: db "Expected: 5", 0
DAT4: db "Expected: 7,541592", 0
DAT5: db "Expected: 2.3", 0
DAT6: db "Expected: 4,6017", 0
DAT7: db "Expected: 13,823", 0
DAT8: db "Expected: 6,0", 0
DAT9: db "Expected: 8,0", 0
DAT10: db "Expected: 27,0", 0
DAT11: db "Expected: 12,0", 0
DAT12: db "Expected: 3,0", 0
DAT13: db "Expected: 15,0", 0
DAT14: db "Expected: 5,0", 0
DAT15: db "Expected: 14,0", 0
DAT16: db "Expected: 42,0", 0
DAT17: db "Expected: 30,0", 0
DAT18: db "Expected: 17,0", 0
DAT19: db "c= ", 0
DAT20: db "Expected: 1", 0
DAT21: db "t= ", 0
DAT22: db "Expected: -30", 0
DAT23: db "d= ", 0
DAT24: db "Expected: 2", 0
DAT25: db "g= ", 0
DAT26: db "Expected: -1", 0
DAT27: db "w= ", 0
DAT28: db "Expected: -4", 0
DAT29: db "Result: ", 0
DAT30: db "Expected: 10", 0
DAT31: db "Expected: 22", 0
DAT32: db "Expected: 12", 0
DAT33: db "Expected: 18", 0
DAT34: db "c<d", 0
DAT35: db "Expected: false", 0
DAT36: db "c==d", 0
DAT37: db "else", 0
DAT38: db "Expected: true", 0
DAT39: db "Ok", 0
f: dd 0
i: dd 0
p: dd 0
a: dd 0
s: dd 0
d: dd 0
m: dd 0
t: dd 0
c: dd 0
y: dd 0
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

section .bss
l: resd 1
r: resd 1
z: resd 1

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

mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
AND eax, ebx
mov [l], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [l]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos0

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon0

pos0:
push eax
push dword positiv
call _printf
add esp, 8

fcon0:

push dword ns
call _printf
add esp, 4

mov eax, 1b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
AND eax, ebx
mov [r], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [r]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos1

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon1

pos1:
push eax
push dword positiv
call _printf
add esp, 8

fcon1:

push dword ns
call _printf
add esp, 4

mov eax, 1b
mov ebx, eax
push ebx
mov eax, 1b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
AND eax, ebx
pop ebx
AND eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
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
jmp fcon2

pos2:
push eax
push dword positiv
call _printf
add esp, 8

fcon2:

push dword ns
call _printf
add esp, 4

mov eax, 1b
mov ebx, eax
push ebx
mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
AND eax, ebx
pop ebx
AND eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos3

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon3

pos3:
push eax
push dword positiv
call _printf
add esp, 8

fcon3:

push dword ns
call _printf
add esp, 4

mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
OR eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos4

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon4

pos4:
push eax
push dword positiv
call _printf
add esp, 8

fcon4:

push dword ns
call _printf
add esp, 4

mov eax, 1b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
OR eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos5

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon5

pos5:
push eax
push dword positiv
call _printf
add esp, 8

fcon5:

push dword ns
call _printf
add esp, 4

mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 0b
OR eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
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
jmp fcon6

pos6:
push eax
push dword positiv
call _printf
add esp, 8

fcon6:

push dword ns
call _printf
add esp, 4

mov eax, 0b
mov ebx, eax
push ebx
mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 0b
OR eax, ebx
pop ebx
OR eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos7

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon7

pos7:
push eax
push dword positiv
call _printf
add esp, 8

fcon7:

push dword ns
call _printf
add esp, 4

mov eax, 0b
mov ebx, eax
push ebx
mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
OR eax, ebx
pop ebx
OR eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos8

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon8

pos8:
push eax
push dword positiv
call _printf
add esp, 8

fcon8:

push dword ns
call _printf
add esp, 4

mov eax, 0b
mov ebx, eax
push ebx
mov eax, 1b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
AND eax, ebx
mov ebx, eax
push ebx
mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
OR eax, ebx
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
AND eax, ebx
pop ebx
AND eax, ebx
pop ebx
OR eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos9

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon9

pos9:
push eax
push dword positiv
call _printf
add esp, 8

fcon9:

push dword ns
call _printf
add esp, 4

mov eax, 1b
NOT eax
cmp eax, 1000000000000000000000000000000b
jl nStage0

mov ebx, 2
sub eax, ebx

nStage0:
mov ebx, 2
add eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos10

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon10

pos10:
push eax
push dword positiv
call _printf
add esp, 8

fcon10:

push dword ns
call _printf
add esp, 4

mov eax, 0b
NOT eax
cmp eax, 1000000000000000000000000000000b
jl nStage1

mov ebx, 2
sub eax, ebx

nStage1:
mov ebx, 2
add eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos11

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon11

pos11:
push eax
push dword positiv
call _printf
add esp, 8

fcon11:

push dword ns
call _printf
add esp, 4

mov eax, 1b
mov [l], eax

mov eax, 0b
NOT eax
cmp eax, 1000000000000000000000000000000b
jl nStage2

mov ebx, 2
sub eax, ebx

nStage2:
mov ebx, 2
add eax, ebx
NOT eax
cmp eax, 1000000000000000000000000000000b
jl nStage3

mov ebx, 2
sub eax, ebx

nStage3:
mov ebx, 2
add eax, ebx
mov [z], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos12

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon12

pos12:
push eax
push dword positiv
call _printf
add esp, 8

fcon12:

push dword ns
call _printf
add esp, 4

push f
push fltOutput
call _scanf
add esp, 8

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

fld dword[f]
sub esp, 8
fstp qword[esp]
push fltOutput
call _printf
add esp, 12

push dword ns
call _printf
add esp, 4

mov eax, 5
mov [i], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [i]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos13

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon13

pos13:
push eax
push dword positiv
call _printf
add esp, 8

fcon13:

push dword ns
call _printf
add esp, 4

push dword DAT3
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
push dword DAT1
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

push dword DAT4
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
push dword DAT1
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

push dword DAT5
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
push dword DAT1
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

push dword DAT6
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
push dword DAT1
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

push dword DAT7
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
push dword DAT1
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

fld dword [flt5]
fld dword [flt5]
fmul

fld dword [flt5]
fmul

fstp dword [t]

push dword DAT0
push dword DAT1
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
fmul

fld dword [flt6]
fmul

fstp dword [t]

push dword DAT0
push dword DAT1
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

fld dword [flt6]
fld dword [flt6]
fld dword [flt6]
fmul

fadd

fstp dword [t]

push dword DAT0
push dword DAT1
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

fld dword [flt7]
fld dword [flt8]
fsub

fstp dword [t]

push dword DAT0
push dword DAT1
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

fld dword [flt9]
fld dword [flt10]
fadd

fstp dword [t]

push dword DAT0
push dword DAT1
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
fld dword [flt6]
fsub

fld dword [flt5]
fadd

fld dword [flt11]
fsub

fstp dword [t]

push dword DAT0
push dword DAT1
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
push dword DAT1
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

fstp dword [t]

push dword DAT0
push dword DAT1
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

fld dword [flt7]
fld dword [flt8]
fmul

fld dword [flt5]
fdiv

fld dword [flt6]
fmul

fstp dword [t]

push dword DAT0
push dword DAT1
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
push dword DAT1
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

fld dword [flt5]
fld dword [flt7]
fld dword [flt8]
fmul

fadd

fstp dword [t]

push dword DAT0
push dword DAT1
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

fld dword [flt7]
fld dword [flt14]
fld dword [flt8]
fdiv

fsub

fstp dword [t]

push dword DAT0
push dword DAT1
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
push dword DAT1
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

push dword DAT18
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 1
mov [c], eax

push dword DAT19
call _printf
add esp, 4

mov eax, [c]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos14

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon14

pos14:
push eax
push dword positiv
call _printf
add esp, 8

fcon14:

push dword ns
call _printf
add esp, 4

push dword DAT20
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

mov [y], eax

push dword DAT21
call _printf
add esp, 4

mov eax, [y]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos15

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon15

pos15:
push eax
push dword positiv
call _printf
add esp, 8

fcon15:

push dword ns
call _printf
add esp, 4

push dword DAT22
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

push dword DAT23
call _printf
add esp, 4

mov eax, [v]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos16

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon16

pos16:
push eax
push dword positiv
call _printf
add esp, 8

fcon16:

push dword ns
call _printf
add esp, 4

push dword DAT24
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT25
call _printf
add esp, 4

mov eax, [g]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos17

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon17

pos17:
push eax
push dword positiv
call _printf
add esp, 8

fcon17:

push dword ns
call _printf
add esp, 4

push dword DAT26
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT27
call _printf
add esp, 4

mov eax, [w]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos18

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon18

pos18:
push eax
push dword positiv
call _printf
add esp, 8

fcon18:

push dword ns
call _printf
add esp, 4

push dword DAT28
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

push dword DAT29
call _printf
add esp, 4

mov eax, [z]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos19

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon19

pos19:
push eax
push dword positiv
call _printf
add esp, 8

fcon19:

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

push dword DAT29
call _printf
add esp, 4

mov eax, [g]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos20

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon20

pos20:
push eax
push dword positiv
call _printf
add esp, 8

fcon20:

push dword ns
call _printf
add esp, 4

push dword DAT31
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

push dword DAT29
call _printf
add esp, 4

mov eax, [c]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos21

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon21

pos21:
push eax
push dword positiv
call _printf
add esp, 8

fcon21:

push dword ns
call _printf
add esp, 4

push dword DAT32
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

push dword DAT29
call _printf
add esp, 4

mov eax, [c]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos22

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon22

pos22:
push eax
push dword positiv
call _printf
add esp, 8

fcon22:

push dword ns
call _printf
add esp, 4

push dword DAT33
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
jl cjl0
jmp con0

cjl0:
push dword DAT34
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT35
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

jmp cnt0

con0:
mov eax, [d]
mov ebx, eax
push ebx

mov eax, [c]
pop ebx

cmp eax, ebx
je cje1
jmp con1

cje1:
push dword DAT36
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT35
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

jmp cnt0

con1:
push dword DAT37
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

push dword DAT38
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

cnt0:
mov eax, 0
mov [i], eax

point:
mov eax, [i]
push eax
mov ebx, 1
pop eax
add eax, ebx

mov [i], eax

push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [i]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos23

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon23

pos23:
push eax
push dword positiv
call _printf
add esp, 8

fcon23:

push dword ns
call _printf
add esp, 4

mov eax, 5
mov ebx, eax
push ebx

mov eax, [i]
pop ebx

cmp eax, ebx
jl cjl2
jmp con2

cjl2:
jmp point
jmp cnt1

con2:
cnt1:
push dword DAT39
call _printf
add esp, 4


push dword ns
call _printf
add esp, 4

mov eax, 0
mov [i], eax

fStage0:
mov eax, 10
mov ebx, eax
push ebx

mov eax, [i]
pop ebx

cmp eax, ebx
jl cjl3
jmp con3

cjl3:
push dword DAT0
push dword DAT1
push dword DAT2
call _printf
add esp, 4

mov eax, [i]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos24

xor eax, ebx
push eax
push dword negative
call _printf
add esp, 8
jmp fcon24

pos24:
push eax
push dword positiv
call _printf
add esp, 8

fcon24:

push dword ns
call _printf
add esp, 4

mov eax, [i]
push eax
mov ebx, 2
pop eax
add eax, ebx

mov [i], eax

jmp fStage0
jmp cnt2

con3:
cnt2:
ret 0
