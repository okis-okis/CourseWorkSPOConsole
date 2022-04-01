BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
fltOutput: db "%f", 0
DAT0: db "", 0
DAT1: db "", 0
i: dd 0
p: dd 0
f: dd 0
d: dd 0
flt0 : dd 4.4
flt1 : dd 3.141591

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
push dword DAT1
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

mov eax, [i]
mov [p], eax

push dword DAT0
push dword DAT1
call _printf
add esp, 4

mov eax, [p]
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

fld dword [flt0]
fstp dword [f]

push dword DAT0
push dword DAT1
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

fld dword [flt1]
fstp dword [d]

push dword DAT0
push dword DAT1
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

ret 0
