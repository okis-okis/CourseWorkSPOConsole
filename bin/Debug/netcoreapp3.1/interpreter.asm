BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
fltOutput: db "%f", 0
DAT0: db "", 0

section .bss
t: resd 1
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
mov [t], eax

push dword DAT0
call _printf
add esp, 4

mov eax, [t]
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

mov eax, 1b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
AND eax, ebx
mov [r], eax

push dword DAT0
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

mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
OR eax, ebx
mov [z], eax

push dword DAT0
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

mov eax, 1b
mov ebx, eax
push ebx
pop ebx
mov eax, 1b
OR eax, ebx
mov [z], eax

push dword DAT0
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

mov eax, 0b
mov ebx, eax
push ebx
pop ebx
mov eax, 0b
OR eax, ebx
mov [z], eax

push dword DAT0
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
jmp con10

pos10:
push eax
push dword positiv
call _printf
add esp, 8

con10:

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
jmp con11

pos11:
push eax
push dword positiv
call _printf
add esp, 8

con11:

push dword ns
call _printf
add esp, 4

mov eax, 1b
mov [t], eax

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
jmp con12

pos12:
push eax
push dword positiv
call _printf
add esp, 8

con12:

push dword ns
call _printf
add esp, 4

ret 0
