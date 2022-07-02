DO $$
BEGIN
if (not exists (select 1 from Builds)) THEN
    insert into Builds (title)
    values
        ('War Bruiser'),
        ('Battlemage'),
        ('Musket duelist'),
        ('Bow AoE Damager'),
        ('Unkillable Hatchet PvP');
end if;
-- if (exists (SELECT 1 from Builds)) THEN
--     raise notice 'table has rows';
-- end if;
END $$;