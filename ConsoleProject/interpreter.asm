BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
DAT0: db "%d", 0
DAT1: db "Result:", 0
DAT2: db "c = ", 0
DAT3: db "d = ", 0
DAT4: db "g = ", 0
DAT5: db "i = ", 0
DAT6: db "t = ", 0
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

push eax
mov eax, 0
mov ebx, 1
sub eax, ebx

mov ebx, eax
push ebx
pop ebx
pop eax
mul ebx

mov [i], eax

push dword DAT1
call printf
add esp, 4

push dword ns
call printf
add esp, 4

push dword DAT2
call printf
add esp, 4

mov eax, [c]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos0

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con0

pos0:
push eax
push dword positiv
call printf
add esp, 8

con0:
push dword ns
call printf
add esp, 4

push dword DAT3
call printf
add esp, 4

mov eax, [d]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos1

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con1

pos1:
push eax
push dword positiv
call printf
add esp, 8

con1:
push dword ns
call printf
add esp, 4

push dword DAT4
call printf
add esp, 4

mov eax, [g]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos2

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con2

pos2:
push eax
push dword positiv
call printf
add esp, 8

con2:
push dword ns
call printf
add esp, 4

push dword DAT5
call printf
add esp, 4

mov eax, [i]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos3

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con3

pos3:
push eax
push dword positiv
call printf
add esp, 8

con3:
push dword ns
call printf
add esp, 4

push dword DAT6
call printf
add esp, 4

mov eax, [t]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos4

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con4

pos4:
push eax
push dword positiv
call printf
add esp, 8

con4:
push dword ns
call printf
add esp, 4

ret 0
