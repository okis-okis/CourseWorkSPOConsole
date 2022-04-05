BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
fltOutput: db "%f", 0
DAT0: db "", 0
i: dd 0

section .bss

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

fStage0:
mov eax, 10
mov ebx, eax
push ebx

mov eax, [i]
pop ebx

cmp eax, ebx
jl cjl0
jmp con0

cjl0:
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

mov eax, [i]
push eax
mov ebx, 1
pop eax
add eax, ebx

mov [i], eax

jmp fStage0
jmp cnt0

con0:
cnt0:
ret 0
