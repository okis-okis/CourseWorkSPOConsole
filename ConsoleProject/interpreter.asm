BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
DAT0: db "%d", 0
DAT1: db "Result:", 0
DAT2: db "eax<ebx", 10, 0
DAT3: db "eax>ebx", 10, 0
DAT4: db "eax==ebx", 10, 0
DAT5: db "eax!=ebx", 10, 0

i: dq 0
t: dq 0

section .text
global _main
extern _printf
extern _scanf
_main:

xor eax, eax
xor ebx, ebx
xor ecx, ecx
xor edx, edx

mov eax, 6
mov ebx, 6
cmp eax, ebx
jl c1
jg c2
je c3
jne c4

c1:
push dword DAT2
call _printf
add esp, 4
jmp con

c2:
push dword DAT3
call _printf
add esp, 4
jmp con

c3:
push dword DAT4
call _printf
add esp, 4
jmp con

c4:
push dword DAT5
call _printf
add esp, 4
jmp con

con:

ret 0