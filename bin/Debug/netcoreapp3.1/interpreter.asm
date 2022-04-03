BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
fltOutput: db "%f", 0
DAT0: db "", 0
i: dd 0

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

mov eax, 5
mov ebx, eax
push ebx

mov eax, [i]
pop ebx

cmp eax, ebx
jl cjl1
jmp con1

cjl1:
jmp point
jmp cnt0

con1:
cnt0:
ret 0
