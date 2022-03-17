BITS 32

section .data
DAT0: db "%d", 10, 0
DAT1: db "c = %d", 10, 0
DAT2: db "d = %d", 10, 0
DAT3: db "g = %d", 10, 0
DAT4: db "i = %d", 10, 0
DAT5: db "t = %d", 10, 0
i: dq 0
t: dq 0
c: dq 0
d: dq 0
g: dq 0

section .text
global main
extern printf
extern scanf
main:

xor eax, eax
xor ebx, ebx
xor ecx, ecx
xor edx, edx

push t
push dword DAT0
call scanf
add esp, 8

mov eax, 5
mov ebx, [t]
add eax, ebx

mov [c], eax

mov eax, [c]
mov ebx, 11
add eax, ebx

mov [d], eax

mov eax, 5
mov ebx, 2
sub eax, ebx

push eax
mov ebx, 10
pop eax
mul ebx

mov [g], eax

mov eax, 5
mov ebx, 10
add eax, ebx

push eax
mov eax, [g]
mov ebx, [d]
sub eax, ebx

push eax
mov ebx, [c]
pop eax
mul ebx

mov ebx, eax
push ebx
pop ebx
pop eax
add eax, ebx

mov [i], eax

mov eax, [c]
push eax
push dword DAT1
call printf
add esp, 8

mov eax, [d]
push eax
push dword DAT2
call printf
add esp, 8

mov eax, [g]
push eax
push dword DAT3
call printf
add esp, 8

mov eax, [i]
push eax
push dword DAT4
call printf
add esp, 8

mov eax, [t]
push eax
push dword DAT5
call printf
add esp, 8

ret 0
